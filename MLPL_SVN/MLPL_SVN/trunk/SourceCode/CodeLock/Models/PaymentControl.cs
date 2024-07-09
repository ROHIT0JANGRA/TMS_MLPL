//  
// Type: CodeLock.Models.PaymentControl
//  
//  
//  

namespace CodeLock.Models
{
  public class PaymentControl
  {
    public PaymentControl()
    {
      this.PaymentDetails = new Payment();
    }

    public Payment PaymentDetails { get; set; }
  }
}
