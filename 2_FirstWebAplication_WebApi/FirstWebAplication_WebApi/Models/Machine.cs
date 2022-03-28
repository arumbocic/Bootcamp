using System;

namespace FirstWebAplication_WebApi.Models
{
    public class Machine
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Type { get; set; }
        public string Brand { get; set; }

        public Machine(Guid id, string type, string brand)
        {
            Id = id;
            Type = type;
            Brand = brand;
        }
        public Machine(string type, string brand)
        {
            // zašto mi se ne kreira Id kad preko Postmana pošaljem POST (radi kad dodam defaultnu vrijednost)?
            Id = Guid.NewGuid();
            Type = type;
            Brand = brand;
        }

        public Machine()
        {
        }
    }
}