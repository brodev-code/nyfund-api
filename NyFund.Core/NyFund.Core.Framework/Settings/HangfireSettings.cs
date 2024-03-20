
namespace NyFund.Core.Framework.Settings
{
    public class HangfireSettings
    {
        public bool IsActive { get; set; }

        public string CentralBankCurrenciesJobCronExp { get; set; }
		public string ContractNotificationQueueJobCronExp { get; set; }
	}
}
