using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timer_ajax.Models
{
    public interface IAlertsRepository
    {
        List<Alert> Alerts { get; }
    }

    public class AlertsRepository : IAlertsRepository
    {
        private List<Alert> data;

        public AlertsRepository()
        {
            data = new List<Alert>()
            {
                new Alert() { Msg = "this is alert is 1", TimeRun = DateTime.Now.AddDays(-1) },
                new Alert() { Msg = "this is alert is 2", TimeRun = DateTime.Now.AddHours(-1) },
                new Alert() { Msg = "this is alert is 3", TimeRun = DateTime.Now.AddMinutes(-1) },
                new Alert() { Msg = "this is alert is 4", TimeRun = DateTime.Now.AddMinutes(1) },
                new Alert() { Msg = "this is alert is 5", TimeRun = DateTime.Now.AddMinutes(2)  }
            };
        }

        List<Alert> IAlertsRepository.Alerts => data;

    }
}
