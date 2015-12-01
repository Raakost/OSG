using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gateway.Services;

namespace Gateway.Facade
{
    public class Facade
    {
        public NewsGatewayService GetNewsGateway()
        {
            return new NewsGatewayService();
        }

        public TrainerGatewayService GetTrainerGateway()
        {
            return new TrainerGatewayService();
        }

        public CommentGatewayService GetCommentGateway()
        {
            return new CommentGatewayService();
        }

        public EventGatewayService GetEventGateway()
        {
            return new EventGatewayService();
        }
    }
}
