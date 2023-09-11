using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace steeltoe.data.showcase.Domain
{
    public class Account
    {
        public int Id { get; set; }

        public string Data { get; set; }
    }

}
