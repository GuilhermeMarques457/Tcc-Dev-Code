﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevCode.webapp.Models
{
    public class PerguntaRespostasVM
    {
        public Perguntas Pergunta { get; set; }
        public IList<Respostas> Respostas { get; set; }
    }
}