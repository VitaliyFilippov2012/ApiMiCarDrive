using System;
using System.Linq;
using System.Linq.Expressions;
using Business.Filters;
using DBContext.Models;
using LinqKit;

namespace Business.Heplers
{
    public static partial class FilterHelper
    {
        public static IQueryable<User> Where(this IQueryable<User> source, UserFilter filter)
        {
            if (!(source is ExpandableQuery<User>))
                source = source.AsExpandable();

            return source.Where(BuildUserFilter(filter));
        }

        private static Expression<Func<User, bool>> BuildUserFilter(UserFilter filter)
        {
            var predicate = PredicateBuilder.New<User>(true);
            if (!string.IsNullOrEmpty(filter.UserName))
                predicate = predicate.And(x => x.Name == filter.UserName);
            if (filter.UserId.HasValue)
                predicate = predicate.And(x => x.UserId == filter.UserId);
            return predicate;
        }
    }
}
