﻿using HumansAPI.DTOs;

namespace HumansAPI
{
    public class Response
    {
        public IEnumerable<ReadHumanDTO>? Items { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
    }
}
