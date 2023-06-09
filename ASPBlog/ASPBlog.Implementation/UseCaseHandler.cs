﻿using Newtonsoft.Json;
using ASPBlog.Application.Exceptions;
using ASPBlog.Application.Logging;
using ASPBlog.Application.UseCases;
using ASPBlog.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ASPBlog.Domain.Entities;

namespace ASPBlog.Implementation
{
    public class UseCaseHandler
    {
        
        private IExceptionLoggers _logger;
        private IApplicationUser _user;
        private IUseCaseLogger _useCaseLogger;

        public UseCaseHandler(
            IExceptionLoggers logger,
            IApplicationUser user,
            IUseCaseLogger useCaseLogger)
        {
            _logger = logger;
            _user = user;
            _useCaseLogger = useCaseLogger;
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization(command, data);

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                command.Execute(data);

                stopwatch.Stop();

                Console.WriteLine(command.Name + " Duration: " + stopwatch.ElapsedMilliseconds + " ms.");
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }

        public TResponse HandleQuery<TRequest, TResponse>(IQuery<TRequest, TResponse> query, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization(query, data);

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var response = query.Execute(data);

                stopwatch.Stop();

                Console.WriteLine(query.Name + " Duration: " + stopwatch.ElapsedMilliseconds + " ms.");

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }

        private void HandleLoggingAndAuthorization<TRequest>(IUseCase useCase, TRequest data)
        {
            var isAuthorized = _user.UseCaseIds.Contains(useCase.Id);

            var log = new UseCaseLog
            {
                User = _user.Identity,
                ExecutionDateTime = DateTime.UtcNow,
                UseCaseName = useCase.Name,
                UserId = _user.Id,
                Data = JsonConvert.SerializeObject(data),
                IsAuthorized = isAuthorized
            };

            _useCaseLogger.Log(log);

            if (!isAuthorized)
            {
                throw new ForbiddenExecutionException(useCase.Name, _user.Identity);
            }
        }
    }
}
