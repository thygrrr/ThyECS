// ReSharper disable ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
namespace ECS;

public class Query
{
    public readonly List<Table> Tables;

    internal readonly Archetypes Archetypes;
    internal readonly Mask Mask;

    
    public Query(Archetypes archetypes, Mask mask, List<Table> tables)
    {
        Tables = tables;
        Archetypes = archetypes;
        Mask = mask;
    }

    
    public bool Has(Entity entity)
    {
        var meta = Archetypes.GetEntityMeta(entity.Identity);
        var table = Archetypes.GetTable(meta.TableId);
        return Tables.Contains(table);
    }

    
    internal void AddTable(Table table)
    {
        Tables.Add(table);
    }
}

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
/*
public delegate void QueryAction_CWU<C0, U>(ref C0 comp0, World w, U uniform);
public delegate void QueryAction_CCWU<C0, C1, U>(ref C0 comp0, ref C1 comp1, World w, U uniform);
public delegate void QueryAction_CCCWU<C0, C1, C3, U>(ref C0 comp0, ref C1 comp1, ref C3 comp2, World w, U uniform);
public delegate void QueryAction_CCCCWU<C0, C1, C2, C3, U>(ref C0 c0, ref C1 c1, ref C2 c2, ref C3 c3, World w, U uniform);
public delegate void QueryAction_CCCCCWU<C0, C1, C2, C3, C4, U>(ref C0 c0, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, World w, U uniform);


public delegate void QueryAction_ECWU<C0, U>(in Entity e, ref C0 comp0, World w, U uniform);
public delegate void QueryAction_ECCWU<C0, C1, U>(in Entity e, ref C0 comp0, ref C1 comp1, World w, U uniform);
public delegate void QueryAction_ECCCWU<C0, C1, C3, U>(in Entity e, ref C0 comp0, ref C1 comp1, ref C3 comp2, World w, U uniform);
public delegate void QueryAction_ECCCCWU<C0, C1, C2, C3, U>(in Entity e, ref C0 c0, ref C1 c1, ref C2 c2, ref C3 c3, World w, U uniform);
public delegate void QueryAction_ECCCCCWU<C0, C1, C2, C3, C4, U>(in Entity e, ref C0 c0, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, World w, U uniform);


public delegate void QueryAction_CW<C0>(ref C0 comp0, World w);
public delegate void QueryAction_CCW<C0, C1>(ref C0 comp0, ref C1 comp1, World w);
public delegate void QueryAction_CCCW<C0, C1, C2>(ref C0 comp0, ref C1 comp1, ref C2 comp2, World w);
public delegate void QueryAction_CCCCW<C0, C1, C2, C3>(ref C0 c0, ref C1 c1, ref C2 c2, ref C3 c3, World w);
public delegate void QueryAction_CCCCCW<C0, C1, C2, C3, C4>(ref C0 c0, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, World w);


public delegate void QueryAction_ECW<C0>(in Entity e, ref C0 comp0, World w);
public delegate void QueryAction_ECCW<C0, C1>(in Entity e, ref C0 comp0, ref C1 comp1, World w);
public delegate void QueryAction_ECCCW<C0, C1, C2>(in Entity e, ref C0 comp0, ref C1 comp1, ref C2 comp2, World w);
public delegate void QueryAction_ECCCCW<C0, C1, C2, C3>(in Entity e, ref C0 c0, ref C1 c1, ref C2 c2, ref C3 c3, World w);
public delegate void QueryAction_ECCCCCW<C0, C1, C2, C3, C4>(in Entity e, ref C0 c0, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, World w);
*/

public delegate void QueryAction_C<C0>(ref C0 comp0);

public delegate void QueryAction_CC<C0, C1>(ref C0 comp0, ref C1 comp1);

public delegate void QueryAction_CCC<C0, C1, C2>(ref C0 comp0, ref C1 comp1, ref C2 comp2);

public delegate void QueryAction_CCCC<C0, C1, C2, C3>(ref C0 c0, ref C1 c1, ref C2 c2, ref C3 c3);

public delegate void QueryAction_CCCCC<C0, C1, C2, C3, C4>(ref C0 c0, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);


public delegate void QueryAction_CS<C0>(ref C0 comp0, ParallelLoopState state);

public delegate void QueryAction_CCS<C0, C1>(ref C0 comp0, ref C1 comp1, ParallelLoopState state);

public delegate void QueryAction_CCCS<C0, C1, C2>(ref C0 comp0, ref C1 comp1, ref C2 comp2, ParallelLoopState state);

public delegate void QueryAction_CCCCS<C0, C1, C2, C3>(ref C0 c0, ref C1 c1, ref C2 c2, ref C3 c3, ParallelLoopState state);

public delegate void QueryAction_CCCCCS<C0, C1, C2, C3, C4>(ref C0 c0, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ParallelLoopState state);


public delegate void QueryAction_CU<C0, in U>(ref C0 comp0, U uniform);

public delegate void QueryAction_CCU<C0, C1, in U>(ref C0 comp0, ref C1 comp1, U uniform);

public delegate void QueryAction_CCCU<C0, C1, C2, in U>(ref C0 comp0, ref C1 comp1, ref C2 comp2, U uniform);

public delegate void QueryAction_CCCCU<C0, C1, C2, C3, in U>(ref C0 c0, ref C1 c1, ref C2 c2, ref C3 c3, U uniform);

public delegate void QueryAction_CCCCCU<C0, C1, C2, C3, C4, in U>(ref C0 c0, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, U uniform);


public delegate void QueryAction_CUS<C0, in U>(ref C0 comp0, U uniform, ParallelLoopState state);

public delegate void QueryAction_CCUS<C0, C1, in U>(ref C0 comp0, ref C1 comp1, U uniform, ParallelLoopState state);

public delegate void QueryAction_CCCUS<C0, C1, C2, in U>(ref C0 comp0, ref C1 comp1, ref C2 comp2, U uniform, ParallelLoopState state);

public delegate void QueryAction_CCCCUS<C0, C1, C2, C3, in U>(ref C0 c0, ref C1 c1, ref C2 c2, ref C3 c3, U uniform, ParallelLoopState state);

public delegate void QueryAction_CCCCCUS<C0, C1, C2, C3, C4, in U>(ref C0 c0, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, U uniform, ParallelLoopState state);

// ReSharper enable IdentifierTypo
// ReSharper enable InconsistentNaming

/* Big chance we never need them because entities themselves are also a type.
public delegate void QueryAction_EC<C0>(in Entity e, ref C0 comp0);
public delegate void QueryAction_ECC<C0, C1>(in Entity e, ref C0 comp0, ref C1 comp1);
public delegate void QueryAction_ECCC<C0, C1, C2>(in Entity e, ref C0 comp0, ref C1 comp1, ref C2 comp2);
public delegate void QueryAction_ECCCC<C0, C1, C2, C3>(in Entity e, ref C0 c0, ref C1 c1, ref C2 c2, ref C3 c3);
public delegate void QueryAction_ECCCCC<C0, C1, C2, C3, C4>(in Entity e, ref C0 c0, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);

public delegate void QueryAction_ECU<C0, in U>(in Entity e, ref C0 comp0, U uniform);
public delegate void QueryAction_ECCU<C0, C1, in U>(in Entity e, ref C0 comp0, ref C1 comp1, U uniform);
public delegate void QueryAction_ECCCU<C0, C1, C2, in U>(in Entity e, ref C0 comp0, ref C1 comp1, ref C2 comp2, U uniform);
public delegate void QueryAction_ECCCCU<C0, C1, C2, C3, in U>(in Entity e, ref C0 c0, ref C1 c1, ref C2 c2, ref C3 c3, U uniform);
public delegate void QueryAction_ECCCCCU<C0, C1, C2, C3, C4, in U>(in Entity e, ref C0 c0, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, U uniform);
*/



public class Query<C>(Archetypes archetypes, Mask mask, List<Table> tables) : Query(archetypes, mask, tables) where C : struct
{
    public ref C Get(Entity entity)
    {
        var meta = Archetypes.GetEntityMeta(entity.Identity);
        var table = Archetypes.GetTable(meta.TableId);
        var storage = table.GetStorage<C>(Identity.None);
        return ref storage[meta.Row];
    }

    #region Runners
    public void Run(QueryAction_C<C> action)
    {
        Archetypes.Lock();

        foreach (var table in Tables)
        {
            if (table.IsEmpty) continue;
            var storage = table.GetStorage<C>(Identity.None).AsSpan();
            foreach (ref var c in storage) action(ref c);
        }

        Archetypes.Unlock();
    }


    public void Run<U>(QueryAction_CU<C, U> action, U uniform)
    {
        Archetypes.Lock();

        foreach (var table in Tables)
        {
            if (table.IsEmpty) continue;
            var storage = table.GetStorage<C>(Identity.None).AsSpan();
            foreach (ref var c in storage) action(ref c, uniform);
        }

        Archetypes.Unlock();
    }

    
    public void RunParallel(QueryAction_C<C> action)
    {
        Archetypes.Lock();

        Parallel.ForEach(Tables, delegate (Table table)
        {
            if (table.IsEmpty) return;
            var storage = table.GetStorage<C>(Identity.None).AsSpan();
            foreach (ref var c in storage) action(ref c);
        });

        Archetypes.Unlock();
    }


    public void RunParallel<U>(QueryAction_CU<C, U> action, U uniform)
    {
        Archetypes.Lock();

        Parallel.ForEach(Tables, delegate(Table table)
        {
            if (table.IsEmpty) return;
            var storage = table.GetStorage<C>(Identity.None).AsSpan();
            foreach (ref var c in storage) action(ref c, uniform);
        });

        Archetypes.Unlock();
    }
    #endregion

    public void Run(Action<int, C[]> action)
    {
        Archetypes.Lock();

        for (var t = 0; t < Tables.Count; t++)
        {
            var table = Tables[t];

            if (table.IsEmpty) continue;

            var s = table.GetStorage<C>(Identity.None);

            action(table.Count, s);
        }

        Archetypes.Unlock();
    }
}

public class Query<C1, C2>(Archetypes archetypes, Mask mask, List<Table> tables) : Query(archetypes, mask, tables)
    where C1 : struct
    where C2 : struct
{
    public RefValueTuple<C1, C2> Get(Entity entity)
    {
        var meta = Archetypes.GetEntityMeta(entity.Identity);
        var table = Archetypes.GetTable(meta.TableId);
        var storage1 = table.GetStorage<C1>(Identity.None);
        var storage2 = table.GetStorage<C2>(Identity.None);
        return new RefValueTuple<C1, C2>(ref storage1[meta.Row], ref storage2[meta.Row]);
    }

    #region Runners

    public void Run(QueryAction_CC<C1, C2> action)
    {
        Archetypes.Lock();

        foreach (var table in Tables)
        {
            if (table.IsEmpty) continue;
            var storage1 = table.GetStorage<C1>(Identity.None).AsSpan();
            var storage2 = table.GetStorage<C2>(Identity.None).AsSpan();
            for (var i = 0; i < storage1.Length; i++)
            {
                action(ref storage1[i], ref storage2[i]);
            }
        }

        Archetypes.Unlock();
    }


    public void Run<U>(QueryAction_CCU<C1, C2, U> action, U uniform)
    {
        Archetypes.Lock();

        foreach (var table in Tables)
        {
            if (table.IsEmpty) continue;
            var storage1 = table.GetStorage<C1>(Identity.None).AsSpan();
            var storage2 = table.GetStorage<C2>(Identity.None).AsSpan();
            for (var i = 0; i < storage1.Length; i++)
            {
                action(ref storage1[i], ref storage2[i], uniform);
            }
        }

        Archetypes.Unlock();
    }


    public void RunParallel(QueryAction_CC<C1, C2> action)
    {
        Archetypes.Lock();

        Parallel.ForEach(Tables, delegate(Table table)
        {
            if (table.IsEmpty) return;
            var storage1 = table.GetStorage<C1>(Identity.None).AsSpan();
            var storage2 = table.GetStorage<C2>(Identity.None).AsSpan();
            for (var i = 0; i < storage1.Length; i++)
            {
                action(ref storage1[i], ref storage2[i]);
            }
        });

        Archetypes.Unlock();
    }


    public void RunParallel<U>(QueryAction_CCU<C1, C2, U> action, U uniform)
    {
        Archetypes.Lock();

        Parallel.ForEach(Tables, delegate(Table table)
        {
            if (table.IsEmpty) return;
            var storage1 = table.GetStorage<C1>(Identity.None).AsSpan();
            var storage2 = table.GetStorage<C2>(Identity.None).AsSpan();
            for (var i = 0; i < storage1.Length; i++)
            {
                action(ref storage1[i], ref storage2[i], uniform);
            }
        });

        Archetypes.Unlock();
    }

    #endregion
}

public class Query<C1, C2, C3>(Archetypes archetypes, Mask mask, List<Table> tables) : Query(archetypes, mask, tables)
    where C1 : struct
    where C2 : struct
    where C3 : struct
{
    public RefValueTuple<C1, C2, C3> Get(Entity entity)
    {
        var meta = Archetypes.GetEntityMeta(entity.Identity);
        var table = Archetypes.GetTable(meta.TableId);
        var storage1 = table.GetStorage<C1>(Identity.None);
        var storage2 = table.GetStorage<C2>(Identity.None);
        var storage3 = table.GetStorage<C3>(Identity.None);
        return new RefValueTuple<C1, C2, C3>(ref storage1[meta.Row], ref storage2[meta.Row],
            ref storage3[meta.Row]);
    }

    public void Run(Action<int, C1[], C2[], C3[]> action)
    {
        Archetypes.Lock();
        
        for (var t = 0; t < Tables.Count; t++)
        {
            var table = Tables[t];

            if (table.IsEmpty) continue;

            var s1 = table.GetStorage<C1>(Identity.None);
            var s2 = table.GetStorage<C2>(Identity.None);
            var s3 = table.GetStorage<C3>(Identity.None);

            action(table.Count, s1, s2, s3);
        }
        
        Archetypes.Unlock();
    }
    
    public void RunParallel(Action<int, C1[], C2[], C3[]> action)
    {
        Archetypes.Lock();

        Parallel.For(0, Tables.Count, t =>
        {
            var table = Tables[t];
            
            if (table.IsEmpty) return;

            var s1 = table.GetStorage<C1>(Identity.None);
            var s2 = table.GetStorage<C2>(Identity.None);
            var s3 = table.GetStorage<C3>(Identity.None);
            
            action(table.Count, s1, s2, s3);
        });
        
        Archetypes.Unlock();
    }
}

public class Query<C1, C2, C3, C4>(Archetypes archetypes, Mask mask, List<Table> tables) : Query(archetypes, mask, tables)
    where C1 : struct
    where C2 : struct
    where C3 : struct
    where C4 : struct
{
    public RefValueTuple<C1, C2, C3, C4> Get(Entity entity)
    {
        var meta = Archetypes.GetEntityMeta(entity.Identity);
        var table = Archetypes.GetTable(meta.TableId);
        var s1 = table.GetStorage<C1>(Identity.None);
        var s2 = table.GetStorage<C2>(Identity.None);
        var s3 = table.GetStorage<C3>(Identity.None);
        var s4 = table.GetStorage<C4>(Identity.None);
        return new RefValueTuple<C1, C2, C3, C4>(ref s1[meta.Row], ref s2[meta.Row],
            ref s3[meta.Row], ref s4[meta.Row]);
    }

    public void Run(Action<int, C1[], C2[], C3[], C4[]> action)
    {
        Archetypes.Lock();

        for (var t = 0; t < Tables.Count; t++)
        {
            var table = Tables[t];

            if (table.IsEmpty) continue;

            var s1 = table.GetStorage<C1>(Identity.None);
            var s2 = table.GetStorage<C2>(Identity.None);
            var s3 = table.GetStorage<C3>(Identity.None);
            var s4 = table.GetStorage<C4>(Identity.None);

            action(table.Count, s1, s2, s3, s4);
        }

        Archetypes.Unlock();
    }

    public void RunParallel(Action<int, C1[], C2[], C3[], C4[]> action)
    {
        Archetypes.Lock();

        Parallel.For(0, Tables.Count, t =>
        {
            var table = Tables[t];
            
            if (table.IsEmpty) return;

            var s1 = table.GetStorage<C1>(Identity.None);
            var s2 = table.GetStorage<C2>(Identity.None);
            var s3 = table.GetStorage<C3>(Identity.None);
            var s4 = table.GetStorage<C4>(Identity.None);
            
            action(table.Count, s1, s2, s3, s4);
        });
        
        Archetypes.Unlock();
    }
}

public class Query<C1, C2, C3, C4, C5>(Archetypes archetypes, Mask mask, List<Table> tables) : Query(archetypes, mask, tables)
    where C1 : struct
    where C2 : struct
    where C3 : struct
    where C4 : struct
    where C5 : struct
{
    public RefValueTuple<C1, C2, C3, C4, C5> Get(Entity entity)
    {
        var meta = Archetypes.GetEntityMeta(entity.Identity);
        var table = Archetypes.GetTable(meta.TableId);
        var s1 = table.GetStorage<C1>(Identity.None);
        var s2 = table.GetStorage<C2>(Identity.None);
        var s3 = table.GetStorage<C3>(Identity.None);
        var s4 = table.GetStorage<C4>(Identity.None);
        var s5 = table.GetStorage<C5>(Identity.None);
        return new RefValueTuple<C1, C2, C3, C4, C5>(ref s1[meta.Row], ref s2[meta.Row],
            ref s3[meta.Row], ref s4[meta.Row], ref s5[meta.Row]);
    }

    public void Run(Action<int, C1[], C2[], C3[], C4[], C5[]> action)
    {
        Archetypes.Lock();
        
        for (var t = 0; t < Tables.Count; t++)
        {
            var table = Tables[t];

            if (table.IsEmpty) continue;

            var s1 = table.GetStorage<C1>(Identity.None);
            var s2 = table.GetStorage<C2>(Identity.None);
            var s3 = table.GetStorage<C3>(Identity.None);
            var s4 = table.GetStorage<C4>(Identity.None);
            var s5 = table.GetStorage<C5>(Identity.None);

            action(table.Count, s1, s2, s3, s4, s5);
        }
        
        Archetypes.Unlock();
    }
    
    public void RunParallel(Action<int, C1[], C2[], C3[], C4[], C5[]> action)
    {
        Archetypes.Lock();

        Parallel.For(0, Tables.Count, t =>
        {
            var table = Tables[t];
            
            if (table.IsEmpty) return;

            var s1 = table.GetStorage<C1>(Identity.None);
            var s2 = table.GetStorage<C2>(Identity.None);
            var s3 = table.GetStorage<C3>(Identity.None);
            var s4 = table.GetStorage<C4>(Identity.None);
            var s5 = table.GetStorage<C5>(Identity.None);
            
            action(table.Count, s1, s2, s3, s4, s5);
        });
        
        Archetypes.Unlock();
    }
}

public class Query<C1, C2, C3, C4, C5, C6> : Query
    where C1 : struct
    where C2 : struct
    where C3 : struct
    where C4 : struct
    where C5 : struct
    where C6 : struct
{
    public Query(Archetypes archetypes, Mask mask, List<Table> tables) : base(archetypes, mask, tables)
    {
    }

    
    public RefValueTuple<C1, C2, C3, C4, C5, C6> Get(Entity entity)
    {
        var meta = Archetypes.GetEntityMeta(entity.Identity);
        var table = Archetypes.GetTable(meta.TableId);
        var s1 = table.GetStorage<C1>(Identity.None);
        var s2 = table.GetStorage<C2>(Identity.None);
        var s3 = table.GetStorage<C3>(Identity.None);
        var s4 = table.GetStorage<C4>(Identity.None);
        var s5 = table.GetStorage<C5>(Identity.None);
        var s6 = table.GetStorage<C6>(Identity.None);
        return new RefValueTuple<C1, C2, C3, C4, C5, C6>(ref s1[meta.Row], ref s2[meta.Row],
            ref s3[meta.Row], ref s4[meta.Row], ref s5[meta.Row],
            ref s6[meta.Row]);
    }

    public void Run(Action<int, C1[], C2[], C3[], C4[], C5[], C6[]> action)
    {
        Archetypes.Lock();
        
        for (var t = 0; t < Tables.Count; t++)
        {
            var table = Tables[t];

            if (table.IsEmpty) continue;

            var s1 = table.GetStorage<C1>(Identity.None);
            var s2 = table.GetStorage<C2>(Identity.None);
            var s3 = table.GetStorage<C3>(Identity.None);
            var s4 = table.GetStorage<C4>(Identity.None);
            var s5 = table.GetStorage<C5>(Identity.None);
            var s6 = table.GetStorage<C6>(Identity.None);

            action(table.Count, s1, s2, s3, s4, s5, s6);
        }
        
        Archetypes.Unlock();
    }
    
    public void RunParallel(Action<int, C1[], C2[], C3[], C4[], C5[], C6[]> action)
    {
        Archetypes.Lock();

        Parallel.For(0, Tables.Count, t =>
        {
            var table = Tables[t];
            
            if (table.IsEmpty) return;

            var s1 = table.GetStorage<C1>(Identity.None);
            var s2 = table.GetStorage<C2>(Identity.None);
            var s3 = table.GetStorage<C3>(Identity.None);
            var s4 = table.GetStorage<C4>(Identity.None);
            var s5 = table.GetStorage<C5>(Identity.None);
            var s6 = table.GetStorage<C6>(Identity.None);
            
            action(table.Count, s1, s2, s3, s4, s5, s6);
        });
        
        Archetypes.Unlock();
    }
}

public class Query<C1, C2, C3, C4, C5, C6, C7> : Query
    where C1 : struct
    where C2 : struct
    where C3 : struct
    where C4 : struct
    where C5 : struct
    where C6 : struct
    where C7 : struct
{
    public Query(Archetypes archetypes, Mask mask, List<Table> tables) : base(archetypes, mask, tables)
    {
    }

    
    public RefValueTuple<C1, C2, C3, C4, C5, C6, C7> Get(Entity entity)
    {
        var meta = Archetypes.GetEntityMeta(entity.Identity);
        var table = Archetypes.GetTable(meta.TableId);
        var s1 = table.GetStorage<C1>(Identity.None);
        var s2 = table.GetStorage<C2>(Identity.None);
        var s3 = table.GetStorage<C3>(Identity.None);
        var s4 = table.GetStorage<C4>(Identity.None);
        var s5 = table.GetStorage<C5>(Identity.None);
        var s6 = table.GetStorage<C6>(Identity.None);
        var s7 = table.GetStorage<C7>(Identity.None);
        return new RefValueTuple<C1, C2, C3, C4, C5, C6, C7>(ref s1[meta.Row], ref s2[meta.Row],
            ref s3[meta.Row], ref s4[meta.Row], ref s5[meta.Row],
            ref s6[meta.Row], ref s7[meta.Row]);
    }

    public void Run(Action<int, C1[], C2[], C3[], C4[], C5[], C6[], C7[]> action)
    {
        Archetypes.Lock();
        
        for (var t = 0; t < Tables.Count; t++)
        {
            var table = Tables[t];

            if (table.IsEmpty) continue;

            var s1 = table.GetStorage<C1>(Identity.None);
            var s2 = table.GetStorage<C2>(Identity.None);
            var s3 = table.GetStorage<C3>(Identity.None);
            var s4 = table.GetStorage<C4>(Identity.None);
            var s5 = table.GetStorage<C5>(Identity.None);
            var s6 = table.GetStorage<C6>(Identity.None);
            var s7 = table.GetStorage<C7>(Identity.None);

            action(table.Count, s1, s2, s3, s4, s5, s6, s7);
        }
        
        Archetypes.Unlock();
    }
    
    public void RunParallel(Action<int, C1[], C2[], C3[], C4[], C5[], C6[], C7[]> action)
    {
        Archetypes.Lock();

        Parallel.For(0, Tables.Count, t =>
        {
            var table = Tables[t];
            
            if (table.IsEmpty) return;

            var s1 = table.GetStorage<C1>(Identity.None);
            var s2 = table.GetStorage<C2>(Identity.None);
            var s3 = table.GetStorage<C3>(Identity.None);
            var s4 = table.GetStorage<C4>(Identity.None);
            var s5 = table.GetStorage<C5>(Identity.None);
            var s6 = table.GetStorage<C6>(Identity.None);
            var s7 = table.GetStorage<C7>(Identity.None);
            
            action(table.Count, s1, s2, s3, s4, s5, s6, s7);
        });
        
        Archetypes.Unlock();
    }
}

public class Query<C1, C2, C3, C4, C5, C6, C7, C8> : Query
    where C1 : struct
    where C2 : struct
    where C3 : struct
    where C4 : struct
    where C5 : struct
    where C6 : struct
    where C7 : struct
    where C8 : struct
{
    public Query(Archetypes archetypes, Mask mask, List<Table> tables) : base(archetypes, mask, tables)
    {
    }

    
    public RefValueTuple<C1, C2, C3, C4, C5, C6, C7, C8> Get(Entity entity)
    {
        var meta = Archetypes.GetEntityMeta(entity.Identity);
        var table = Archetypes.GetTable(meta.TableId);
        var s1 = table.GetStorage<C1>(Identity.None);
        var s2 = table.GetStorage<C2>(Identity.None);
        var s3 = table.GetStorage<C3>(Identity.None);
        var s4 = table.GetStorage<C4>(Identity.None);
        var s5 = table.GetStorage<C5>(Identity.None);
        var s6 = table.GetStorage<C6>(Identity.None);
        var s7 = table.GetStorage<C7>(Identity.None);
        var s8 = table.GetStorage<C8>(Identity.None);
        return new RefValueTuple<C1, C2, C3, C4, C5, C6, C7, C8>(ref s1[meta.Row], ref s2[meta.Row],
            ref s3[meta.Row], ref s4[meta.Row], ref s5[meta.Row],
            ref s6[meta.Row], ref s7[meta.Row], ref s8[meta.Row]);
    }

    public void Run(Action<int, C1[], C2[], C3[], C4[], C5[], C6[], C7[], C8[]> action)
    {
        Archetypes.Lock();
        
        for (var t = 0; t < Tables.Count; t++)
        {
            var table = Tables[t];

            if (table.IsEmpty) continue;

            var s1 = table.GetStorage<C1>(Identity.None);
            var s2 = table.GetStorage<C2>(Identity.None);
            var s3 = table.GetStorage<C3>(Identity.None);
            var s4 = table.GetStorage<C4>(Identity.None);
            var s5 = table.GetStorage<C5>(Identity.None);
            var s6 = table.GetStorage<C6>(Identity.None);
            var s7 = table.GetStorage<C7>(Identity.None);
            var s8 = table.GetStorage<C8>(Identity.None);

            action(table.Count, s1, s2, s3, s4, s5, s6, s7, s8);
        }
        
        Archetypes.Unlock();
    }
    
    public void RunParallel(Action<int, C1[], C2[], C3[], C4[], C5[], C6[], C7[], C8[]> action)
    {
        Archetypes.Lock();

        Parallel.For(0, Tables.Count, t =>
        {
            var table = Tables[t];
            
            if (table.IsEmpty) return;

            var s1 = table.GetStorage<C1>(Identity.None);
            var s2 = table.GetStorage<C2>(Identity.None);
            var s3 = table.GetStorage<C3>(Identity.None);
            var s4 = table.GetStorage<C4>(Identity.None);
            var s5 = table.GetStorage<C5>(Identity.None);
            var s6 = table.GetStorage<C6>(Identity.None);
            var s7 = table.GetStorage<C7>(Identity.None);
            var s8 = table.GetStorage<C8>(Identity.None);
            
            action(table.Count, s1, s2, s3, s4, s5, s6, s7, s8);
        });
        
        Archetypes.Unlock();
    }
}

public class Query<C1, C2, C3, C4, C5, C6, C7, C8, C9> : Query
    where C1 : struct
    where C2 : struct
    where C3 : struct
    where C4 : struct
    where C5 : struct
    where C6 : struct
    where C7 : struct
    where C8 : struct
    where C9 : struct
{
    public Query(Archetypes archetypes, Mask mask, List<Table> tables) : base(archetypes, mask, tables)
    {
    }

    
    public RefValueTuple<C1, C2, C3, C4, C5, C6, C7, C8, C9> Get(Entity entity)
    {
        var meta = Archetypes.GetEntityMeta(entity.Identity);
        var table = Archetypes.GetTable(meta.TableId);
        var s1 = table.GetStorage<C1>(Identity.None);
        var s2 = table.GetStorage<C2>(Identity.None);
        var s3 = table.GetStorage<C3>(Identity.None);
        var s4 = table.GetStorage<C4>(Identity.None);
        var s5 = table.GetStorage<C5>(Identity.None);
        var s6 = table.GetStorage<C6>(Identity.None);
        var s7 = table.GetStorage<C7>(Identity.None);
        var s8 = table.GetStorage<C8>(Identity.None);
        var s9 = table.GetStorage<C9>(Identity.None);
        return new RefValueTuple<C1, C2, C3, C4, C5, C6, C7, C8, C9>(ref s1[meta.Row], ref s2[meta.Row],
            ref s3[meta.Row], ref s4[meta.Row], ref s5[meta.Row],
            ref s6[meta.Row], ref s7[meta.Row], ref s8[meta.Row], ref s9[meta.Row]);
    }

    public void Run(Action<int, C1[], C2[], C3[], C4[], C5[], C6[], C7[], C8[], C9[]> action)
    {
        Archetypes.Lock();
        
        for (var t = 0; t < Tables.Count; t++)
        {
            var table = Tables[t];
            
            if (table.IsEmpty) continue;

            var s1 = table.GetStorage<C1>(Identity.None);
            var s2 = table.GetStorage<C2>(Identity.None);
            var s3 = table.GetStorage<C3>(Identity.None);
            var s4 = table.GetStorage<C4>(Identity.None);
            var s5 = table.GetStorage<C5>(Identity.None);
            var s6 = table.GetStorage<C6>(Identity.None);
            var s7 = table.GetStorage<C7>(Identity.None);
            var s8 = table.GetStorage<C8>(Identity.None);
            var s9 = table.GetStorage<C9>(Identity.None);
            
            action(table.Count, s1, s2, s3, s4, s5, s6, s7, s8, s9);
        }
        
        Archetypes.Unlock();
    }
    
    public void RunParallel(Action<int, C1[], C2[], C3[], C4[], C5[], C6[], C7[], C8[], C9[]> action)
    {
        Archetypes.Lock();

        Parallel.For(0, Tables.Count, t =>
        {
            var table = Tables[t];
            
            if (table.IsEmpty) return;

            var s1 = table.GetStorage<C1>(Identity.None);
            var s2 = table.GetStorage<C2>(Identity.None);
            var s3 = table.GetStorage<C3>(Identity.None);
            var s4 = table.GetStorage<C4>(Identity.None);
            var s5 = table.GetStorage<C5>(Identity.None);
            var s6 = table.GetStorage<C6>(Identity.None);
            var s7 = table.GetStorage<C7>(Identity.None);
            var s8 = table.GetStorage<C8>(Identity.None);
            var s9 = table.GetStorage<C9>(Identity.None);
            
            action(table.Count, s1, s2, s3, s4, s5, s6, s7, s8, s9);
        });
        
        Archetypes.Unlock();
    }
}