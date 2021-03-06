﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DotVVM.Framework.Compilation.Javascript
{
    public class ExtractExpressionVisitor : ExpressionVisitor
    {
        public List<ParameterExpression> ParameterOrder { get; set; } = new List<ParameterExpression>();
        public Dictionary<ParameterExpression, Expression> Replaced { get; set; } = new Dictionary<ParameterExpression, Expression>();
        public Predicate<Expression> Predicate { get; set; }
        readonly string ParameterPrefix;

        public ExtractExpressionVisitor(Predicate<Expression> predicate, string parameterPrefix = "r_")
        {
            Predicate = predicate;
            ParameterPrefix = parameterPrefix;
        }

        public override Expression Visit(Expression node)
        {
            if (node == null) return null;
            node = base.Visit(node);
            if (Predicate(node))
            {
                var par = node.Type == typeof(void) ? Expression.Parameter(typeof(object), ""): Expression.Parameter(node.Type, "r_" + Replaced.Count);
                Replaced.Add(par, node);
                ParameterOrder.Add(par);
                return par;
            }
            else return node;
        }
    }
}
