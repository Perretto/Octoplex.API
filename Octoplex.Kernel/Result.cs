using MediatR;
using System;

namespace Octoplex.Kernel
{
    public struct Result<TFailure, TSuccess>
    {
       
            public TFailure Failure
            {
                get;
                internal set;
            }

            public TSuccess Success
            {
                get;
                internal set;
            }

            public bool IsFailure
            {
                get;
            }

            public bool IsSuccess => !IsFailure;

            //public Option<TFailure> OptionalFailure
            //{
            //    get
            //    {
            //        if (!IsFailure)
            //        {
            //            return Helpers.None;
            //        }

            //        return Helpers.Some(Failure);
            //    }
            //}

            //public Option<TSuccess> OptionalSuccess
            //{
            //    get
            //    {
            //        if (!IsSuccess)
            //        {
            //            return Helpers.None;
            //        }

            //        return Helpers.Some(Success);
            //    }
            //}

            internal Result(TFailure failure)
            {
                IsFailure = true;
                Failure = failure;
                Success = default(TSuccess);
            }

            internal Result(TSuccess success)
            {
                IsFailure = false;
                Failure = default(TFailure);
                Success = success;
            }

            public TResult Match<TResult>(Func<TFailure, TResult> failure, Func<TSuccess, TResult> success)
            {
                if (!IsFailure)
                {
                    return success(Success);
                }

                return failure(Failure);
            }

            public Unit Match(Action<TFailure> failure, Action<TSuccess> success)
            {
                return Match(Helpers.ToFunc(failure), Helpers.ToFunc(success));
            }

            public static implicit operator Result<TFailure, TSuccess>(TFailure failure)
            {
                return new Result<TFailure, TSuccess>(failure);
            }

            public static implicit operator Result<TFailure, TSuccess>(TSuccess success)
            {
                return new Result<TFailure, TSuccess>(success);
            }

            public static Result<TFailure, TSuccess> Of(TSuccess obj)
            {
                return obj;
            }

            public static Result<TFailure, TSuccess> Of(TFailure obj)
            {
                return obj;
            }
        
        //public TFailure Failure
        //{
        //    get;
        //    internal set;
        //}

        //public TSuccess Success
        //{
        //    get;
        //    internal set;
        //}

        //public bool IsFailure
        //{
        //    get;
        //}

        //public bool IsSuccess => !IsFailure;

        ////public Option<TFailure> OptionalFailure
        ////{
        ////    get
        ////    {
        ////        if (!IsFailure)
        ////        {
        ////            return Helpers.None;
        ////        }

        ////        return Helpers.Some(Failure);
        ////    }
        ////}

        ////public Option<TSuccess> OptionalSuccess
        ////{
        ////    get
        ////    {
        ////        if (!IsSuccess)
        ////        {
        ////            return Helpers.None;
        ////        }

        ////        return Helpers.Some(Success);
        ////    }
        ////}

        //public Result(TFailure failure)
        //{
        //    IsFailure = true;
        //    Failure = failure;
        //    Success = default(TSuccess);
        //}

        //public Result(TSuccess success)
        //{
        //    IsFailure = false;
        //    Failure = default(TFailure);
        //    Success = success;
        //}

        //public TResult Match<TResult>(Func<TFailure, TResult> failure, Func<TSuccess, TResult> success)
        //{
        //    if (!IsFailure)
        //    {
        //        return success(Success);
        //    }

        //    return failure(Failure);
        //}

        //public Unit Match(Action<TFailure> failure, Action<TSuccess> success)
        //{
        //    return Match(Helpers.ToFunc(failure), Helpers.ToFunc(success));
        //}

        //public static implicit operator Result<TFailure, TSuccess>(TFailure failure)
        //{
        //    return new Result<TFailure, TSuccess>(failure);
        //}

        //public static implicit operator Result<TFailure, TSuccess>(TSuccess success)
        //{
        //    return new Result<TFailure, TSuccess>(success);
        //}

        //public static Result<TFailure, TSuccess> Of(TSuccess obj)
        //{
        //    return obj;
        //}
    }
}
