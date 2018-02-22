using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mp_test.DAL
{
  public class Message
  {
    public int Id { get; set; }
    public virtual Thread Thread { get; set; }
    public string AuthorId { get; set; }
    public string RecepientId { get; set; }
    public string MessageText { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public bool IsRead { get; set; }

  }
}