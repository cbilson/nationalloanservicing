using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Specs {
    public static class Extensions {

        public static void Each<T>(this ICollection<T> things, Action<T, int> action) {
            for (var i = 0; i < things.Count; i++)
                action(things.ElementAt(i), i);
        }
    }
}
