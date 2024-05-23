using BaseLibrary.DTO;
using BaseLibrary.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary.Services
{
    public interface IPaymentService
    {
        public Task<PaymentResponse> Pay(IPayDTO pay);
    }
}
