using System;
using System.Collections.Generic;
using static ISO_MTI_DE.Program;


namespace new_is
{
    internal class ISO
    {

        public static List<DataElements> Balance()
        {
            DateTime currentTime = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
            string formattedTime = currentTime.ToString(" HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            // Create a DataElements object for current time
            DataElements currentTimeData = new DataElements
            {
                Id = "DE-055", // Data Element ID
                PositionInTheMsg = 33, //suitable position
                Name = "Current Time",
                Value = formattedTime
            };
            List<DataElements> balance = new List<DataElements>
        {
            new DataElements { Id = "DE-003", PositionInTheMsg = 3, Name = "Processing Code", Value = "987654" },
            new DataElements { Id = "DE-004", PositionInTheMsg = 4, Name = "Transaction Amount", Value = "250000" },
        };
            balance.Add(currentTimeData);
            return balance;
        }
        public static List<DataElements> Withdrawal()
        {
            DateTime currentTime = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
            string formattedTime = currentTime.ToString(" HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);


            // Create a DataElements object for current time
            DataElements currentTimeData = new DataElements
            {
                Id = "DE-055", //Data Element ID
                PositionInTheMsg = 33, //suitable position
                Name = "Current Time",
                Value = formattedTime
            };

            List<DataElements> withdrawal = new List<DataElements>
        {
            new DataElements{ Id = "DE-003", PositionInTheMsg = 3, Name = "Processing Code", Value = "675849" },
            new DataElements { Id = "DE-004", PositionInTheMsg = 4, Name = "Transaction Amount", Value = "000001230000" },
        };
            withdrawal.Add(currentTimeData);
            return withdrawal;
        }
        public static List<DataElements> SignOnData()
        {
            DateTime currentTime = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
            string formattedTime = currentTime.ToString(" HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);


            // Create a DataElements object for current time
            DataElements currentTimeData = new DataElements
            {
                Id = "DE-055", //Data Element ID
                PositionInTheMsg = 33, //suitable position
                Name = "Current Time",
                Value = formattedTime
            };

            List<DataElements> signOnData = new List<DataElements>
        {
            new DataElements { Id = "DE-003", PositionInTheMsg = 4, Name = "Processing Code", Value = "780000" },
            new DataElements { Id = "DE-011", PositionInTheMsg = 11, Name = "System Trace Number", Value = "125456" },
        };
            signOnData.Add(currentTimeData);
            return signOnData;
        }
        public static List<DataElements> EnhancedNetwork()
        {
            DateTime currentTime = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
            string formattedTime = currentTime.ToString(" HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);


            // Create a DataElements object for current time
            DataElements currentTimeData = new DataElements
            {
                Id = "DE-055", //Data Element ID
                PositionInTheMsg = 33, //suitable position
                Name = "Current Time",
                Value = formattedTime
            };
            List<DataElements> enhancedNetwork = new List<DataElements>
        {
            new DataElements { Id = "DE-003", PositionInTheMsg = 3, Name = "Processing Code", Value = "998700" },
            new DataElements { Id = "DE-011", PositionInTheMsg = 11, Name = "System Trace Number", Value = "657421" },
            new DataElements { Id = "DE-025", PositionInTheMsg = 25, Name = "POS Condition Code", Value = "989898" },
        };

            enhancedNetwork.Add(currentTimeData);
            return enhancedNetwork;

        }
        public static List<DataElements> SignoffData()
        {
            DateTime currentTime = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
            string formattedTime = currentTime.ToString(" HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);


            // Create a DataElements object for current time
            DataElements currentTimeData = new DataElements
            {
                Id = "DE-055", //Data Element ID
                PositionInTheMsg = 33, //position
                Name = "Current Time",
                Value = formattedTime
            };
            List<DataElements> signoffData = new List<DataElements>
        {
            new DataElements { Id = "DE-003", PositionInTheMsg = 4, Name = "Processing Code", Value = "920570" },
            new DataElements { Id = "DE-011", PositionInTheMsg = 11, Name = "System Trace Number", Value = "100988" },
        };
            signoffData.Add(currentTimeData);
            return signoffData;
        }

    }

}
