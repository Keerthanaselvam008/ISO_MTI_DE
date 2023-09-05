using new_is;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ISO_MTI_DE
{

    class Program : ISO
    {
        static void Main(string[] args)
        {
            Networkmessage(); // calling the method            
        }

        public static void Networkmessage()
        {

            List<DataElements> balance = Balance();
            List<DataElements> withdrawal = Withdrawal();
            List<DataElements> signOnData = SignOnData();
            List<DataElements> enhancedNetwork = EnhancedNetwork();
            List<DataElements> signoffData = SignoffData();


            // Add the current time DataElements to the desired message lists

            DateTime currentTime = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
            string formattedTime = currentTime.ToString("HHmmss", System.Globalization.CultureInfo.InvariantCulture);


            // Create a DataElements object for current time
            DataElements currentTimeData = new DataElements
            {
                Id = "DE-055", //Data Element ID
                PositionInTheMsg = 33, //suitable position
                Name = "Current Time",
                Value = formattedTime
            };



            string headerValue = "ISO004000000"; // header value
            LengthType lengthType = LengthType.Fixed; // Fixed or Variable

            string balanceInquiryMTI = "0200"; // MTI value for Balance Inquiry
            string cashWithdrawalMTI = "0100"; // MTI value for Cash Withdrawal
            string signOnMTI = "0801"; // MTI value for Sign On
            string enhancedNetworkMTI = "0801"; // MTI value for Enhanced Network Message
            string signoff = "0802";
            Console.WriteLine("Sign On Message:\n" + (BuilderofMessage.TransactionMessage(signOnMTI, signOnData, headerValue, lengthType, formattedTime)) + "\n");
            Console.WriteLine("Balance Inquiry Message:\n" + BuilderofMessage.TransactionMessage(balanceInquiryMTI, balance, headerValue, lengthType, formattedTime) + "\n");
            Console.WriteLine("Cash Withdrawal Message:\n" + BuilderofMessage.TransactionMessage(cashWithdrawalMTI, withdrawal, headerValue, lengthType, formattedTime) + "\n");
            Console.WriteLine("Enhanced Network Message:\n" + BuilderofMessage.TransactionMessage(enhancedNetworkMTI, enhancedNetwork, headerValue, lengthType, formattedTime) + "\n");
            Console.WriteLine("Sign off Message:\n" + BuilderofMessage.TransactionMessage(signoff, signoffData, headerValue, lengthType, formattedTime) + "\n");
            Console.ReadKey();

        }

        public class BuilderofMessage
        {
            public static string TransactionMessage(string mti, List<DataElements> dataElements, string headerValue, LengthType lengthType, string currentTime)
            {
                // Create a boolean array to represent the bitmap
                bool[] bitmapArray = new bool[128]; // Assuming a maximum of 128 bits for ISO 8583 messages

                foreach (DataElements de in dataElements)
                {
                    int positionOfBit = de.PositionInTheMsg - 1;
                    bitmapArray[positionOfBit] = true;
                }

                // Convert the boolean array to an ASCII string
                StringBuilder asciiBitmap = new StringBuilder();
                for (int i = 0; i < bitmapArray.Length; i += 8)
                {
                    int asciiValue = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        asciiValue <<= 1;
                        if (i + j < bitmapArray.Length && bitmapArray[i + j])
                        {
                            asciiValue |= 1;
                        }
                    }
                    asciiBitmap.Append((char)asciiValue);
                }

                StringBuilder Msg = new StringBuilder();

                // Add message header
                Msg.Append(headerValue);

                // Add MTI (Message Type Indicator)
                Msg.Append(mti);

                // Add message length based on length type
                if (lengthType == LengthType.Fixed)
                {
                    int messageLength = headerValue.Length + mti.Length + 4 + asciiBitmap.Length + dataElements.Sum(de => de.Value.Length);
                    Msg.Append(messageLength.ToString().PadLeft(4, '0'));
                }

                Msg.Append(asciiBitmap.ToString());

                foreach (DataElements de in dataElements)
                {
                    Msg.Append(de.Value);
                }

                return Msg.ToString();
            }
        }

        public enum LengthType
        {
            Fixed,
            Variable
        }
        public class DataElements
        {
            public string Id { get; set; }
            public int PositionInTheMsg { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
            public enum LengthType
            {
                Fixed,
                Variable
            }
        }

    }
}
