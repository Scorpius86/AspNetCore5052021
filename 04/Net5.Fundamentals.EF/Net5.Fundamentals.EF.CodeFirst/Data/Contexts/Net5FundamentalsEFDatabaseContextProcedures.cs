﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Net5.Fundamentals.EF.CodeFirst.Data.Entities;

namespace Net5.Fundamentals.EF.CodeFirst.Data.Contexts
{
    public partial class Net5FundamentalsEFDatabaseContext
    {
        private Net5FundamentalsEFDatabaseContextProcedures _procedures;

        public Net5FundamentalsEFDatabaseContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new Net5FundamentalsEFDatabaseContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public Net5FundamentalsEFDatabaseContextProcedures GetProcedures()
        {
            return Procedures;
        }
    }

    public partial class Net5FundamentalsEFDatabaseContextProcedures
    {
        private readonly Net5FundamentalsEFDatabaseContext _context;

        public Net5FundamentalsEFDatabaseContextProcedures(Net5FundamentalsEFDatabaseContext context)
        {
            _context = context;
        }

        public virtual async Task<uspListPostResult[]> uspListPostAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<uspListPostResult>("EXEC @returnValue = [Blog].[uspListPost]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
