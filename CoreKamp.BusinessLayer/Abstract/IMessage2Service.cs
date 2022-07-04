﻿using CoreKamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreKamp.BusinessLayer.Abstract
{
    public interface IMessage2Service:IGenericService<Message2>
    {
        List<Message2> GetInBoxListByWriter(int id);
        List<Message2> GetSendBoxListByWriter(int id);
    }
}

