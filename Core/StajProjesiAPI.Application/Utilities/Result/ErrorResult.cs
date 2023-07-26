﻿

namespace StajProjesiAPI.Application.Utilities.Result
{
    public class ErrorResult : Result
    {

        public ErrorResult(string message)
            : base(success: false, message)
        {
        }

        public ErrorResult()
            : base(success: false)
        {
        }
    }
}