﻿namespace StockExchange_EGID.Server.Utilities
{
    public class UserManagerResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
