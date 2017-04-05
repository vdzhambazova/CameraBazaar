using CameraBazaar.Data;

namespace CameraBazaar.Services
{
    public class Service
    {
        protected CameraBazaarContext context;

        protected Service()
        {
            this.context = new CameraBazaarContext();
        }
    }
}