using System;
using System.Collections.Generic;

namespace mpi {
    public static class Collective {

        public static void ReduceAll<T>(ref T toBeReduced, MPI.ReduceFunc<T> f) {
            // ReduceAll is identical to Reduce except that at the end, all nodes have a copy of the reduction. 
            // That is, ReduceAll is conceptually equivalent to a Reduce followed by a Broadcast. When the 
            // ReduceAll is finished, toBeReduced (on each node) will be a copy of the reduction. 
        }

        public static List<T> Gather<T>(long toWhere, List<T> toBeGathered) {
            // Gather is very similar to Reduce except that instead of performing a reduction, Gather 
            // concatenates the data from the toBeGathered lists on each node, leaving the final assembled 
            // list returned on node toWhere; all other nodes receive null as a return result. The final list must 
            // be assembled in node rank order: the data from node 0, node 1, node 2 and so forth. 
            // Obviously, large lists can be challenging to transfer among nodes and making multiple copies 
            // of lists can be expensive (remember Permute?). Avoid unnecessary data and process 
            // replication if possible.
            return null;
        }

        public static List<T> GatherAll<T>(List<T> toBeGathered) {
            // GatherAll is to Gather as ReduceAll is to Reduce. Need more be said? Except, one should note 
            // that if Gather was expensive, GatherAll will be far more intense. There is likely a tradeoff to be 
            // made regarding the number of messages sent and the amount of replicated work. Would 
            // several broadcast-like transfers of partial gathers be preferable to moving copies of a very 
            // large data set? Rather than a Gather followed by a Broadcast, it might be preferable to send 
            // partial gathers in both directions across a fold. Something to ponder, at least.
            return null;
        }

        public static List<T> Scatter<T>(long fromWhere, List<T> toScatter) {
            // Scatter is the dual function to Gather. Rather than building a large concatenated data set, an 
            // existing data set is broken down such that each node receives a “fair” portion. The goal of 
            // “fair” to to apportion the data set as close to “balanced” as possible. That means, for example, 
            // that is would be better to have 4 nodes (of 8) receive 10 items and the other 4 nodes 9 items 
            // each, rather than having 7 nodes receive 10 items each and the remaining node only 6.
            return null;
        }

    }
}