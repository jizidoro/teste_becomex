using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace roboapi.Models
{
    public class Robo
    {
        public Cabeca cabeca { get; set; }
        public BracoDireito bracoDireito { get; set; }
        public BracoEsquerdo bracoEsquerdo { get; set; }
    }
}


