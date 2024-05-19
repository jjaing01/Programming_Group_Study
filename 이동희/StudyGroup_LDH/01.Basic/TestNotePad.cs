using System;
using System.Collections.Generic;
using System.Linq;

public enum ScheduleKindType
{
    None = 0,
    Date = 1,
    Chronology = 2,
    AlignedChronology = 3,
    Max = 4,
}
/// <summary>
/// 재화를 특정하기 위한 정보입니다.
/// </summary>
public partial class CurrencyIndex : IEquatable<CurrencyIndex>
{
    public CurrencyIndex()
    {
        CurrencyCuid = 0;
        ScheduleKind = ScheduleKindType.None;
    }

    public CurrencyIndex(long cuid, ScheduleKindType scheduleKind)
    {
        CurrencyCuid = cuid;
        ScheduleKind = scheduleKind;
    }

    /// <summary>
    /// 재화 Cuid 입니다.
    /// </summary>
    public long CurrencyCuid { get; set; }

    /// <summary>
    /// 기간제 재화 아이템에 설정된 스케줄 종류입니다.
    /// 기간제 재화 아이템이 아니거나 포인트 재화일 경우, ScheduleKindType.None으로 설정됩니다.
    /// </summary>
    public ScheduleKindType ScheduleKind { get; set; }

    public bool Equals(CurrencyIndex? other) =>
        this.CurrencyCuid == other.CurrencyCuid &&
        this.ScheduleKind == other.ScheduleKind;

    public override bool Equals(object obj) =>
        obj is not null && obj is CurrencyIndex currencyIndex &&
        this.CurrencyCuid == currencyIndex.CurrencyCuid &&
        this.ScheduleKind == currencyIndex.ScheduleKind;

    public override int GetHashCode()
    {
        return HashCode.Combine(CurrencyCuid, ScheduleKind);
    }

    public override string ToString() =>
        $"{nameof(CurrencyCuid)}={CurrencyCuid}," +
        $"{nameof(ScheduleKind)}={ScheduleKind}";

}

/*
 * CurrencyIndexEqualComparer 클래스를 구현할 필요가 없습니다.
 * 이미 CurrencyIndex 클래스 자체에서 IEquatable<CurrencyIndex> 인터페이스를 구현하여 동일한 기능을 제공하기 때문입니다.
 * 
 * CurrencyIndexEqualComparer를 구현해야 할 상황은 일반적으로 다음과 같습니다.

1. 기본 동등성 비교 외에 추가적인 비교 로직이 필요한 경우
- 때로는 객체의 동등성을 판단할 때 기본적으로 제공되는 비교 방법 외에도 특정한 비교 로직이 필요한 경우가 있습니다.
- 예를 들어, 특정 속성의 비교를 무시하거나, 특정 조건에 따라 동등성 여부를 결정해야 하는 경우가 있습니다.
- 이런 경우에는 IEqualityComparer<T> 인터페이스를 구현하는 클래스를 만들어서 추가적인 비교 로직을 정의할 수 있습니다.

2. Immutable한 클래스의 경우
- 클래스가 Immutable하고 값 객체(Value Object)인 경우에는 클래스 자체에 Equals() 및 GetHashCode() 메서드를 구현하는 것이 일반적으로 더 나은 방법입니다.
- 그러나 가변적인 상태를 가지고 있거나, 외부에서 값을 변경할 수 있는 경우에는 외부에서 비교 로직을 제공하는 것이 안전할 수 있습니다.

3. 클래스의 소유권이 없는 경우
- 클래스를 수정할 수 없는 상황에서 동등성 비교를 구현해야 할 때가 있습니다.
- 예를 들어, 외부 라이브러리에서 제공하는 클래스를 키로 사용해야 하는데, 이 클래스가 IEquatable<T>를 구현하지 않은 경우가 있습니다.
- 이런 경우에는 해당 클래스에 대한 비교 로직을 제공하는 비교자 클래스를 만들어서 사용할 수 있습니다.

따라서 위 상황에서는 CurrencyIndexEqualComparer와 같은 비교자 클래스를 구현하여 객체의 동등성을 비교하는 것이 좋습니다.
 */
public class CurrencyIndexEqualComparer : IEqualityComparer<CurrencyIndex>
{
    public static CurrencyIndexEqualComparer Instance { get; } = new CurrencyIndexEqualComparer();

    public static bool CurrencyIndexEquals(CurrencyIndex lhs, CurrencyIndex rhs) =>
        lhs.CurrencyCuid == rhs.CurrencyCuid &&
        lhs.ScheduleKind == rhs.ScheduleKind;

    public virtual bool Equals(CurrencyIndex? lhs, CurrencyIndex? rhs) =>
        lhs is not null &&
        rhs is not null &&
        CurrencyIndexEquals(lhs, rhs);

    public int GetHashCode(CurrencyIndex currencyIndex) =>
        HashCode.Combine(currencyIndex.CurrencyCuid, currencyIndex.ScheduleKind);
}

public static class DictionaryExtension
{
    public static TValue AddOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, Func<TValue> addValueFactory, Func<TValue, TValue> updateValueFactory)
        where TKey : notnull
    {
        if (dict.TryGetValue(key, out var value))
        {
            value = updateValueFactory.Invoke(value);
            dict[key] = value;
        }
        else
        {
            value = addValueFactory.Invoke();
            dict.Add(key, value);
        }

        return value;
    }

    public static TValue AddOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue addValue, Func<TValue, TValue> updateValueFactory)
        where TKey : notnull
    {
        if (dict.TryGetValue(key, out var value))
        {
            value = updateValueFactory.Invoke(value);
            dict[key] = value;
        }
        else
        {
            value = addValue;
            dict.Add(key, addValue);
        }

        return value;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        var currencyIndexToAmount = new Dictionary<CurrencyIndex, long>(CurrencyIndexEqualComparer.Instance);
        
        var currencyIndex4 = new CurrencyIndex(3, ScheduleKindType.Date);
        var currencyIndex1 = new CurrencyIndex(3, ScheduleKindType.Date);
        var currencyIndex2 = new CurrencyIndex(2, ScheduleKindType.Chronology);
        var currencyIndex5 = new CurrencyIndex(2, ScheduleKindType.AlignedChronology);
        var currencyIndex6 = new CurrencyIndex(2, ScheduleKindType.Date);
        var currencyIndex7 = new CurrencyIndex(2, ScheduleKindType.Date);
        var currencyIndex8 = new CurrencyIndex(1, ScheduleKindType.Date);
        var currencyIndex9 = new CurrencyIndex(1, ScheduleKindType.Date);
        var currencyIndex3 = new CurrencyIndex(1, ScheduleKindType.Chronology);


        var isSame = currencyIndex6.Equals(currencyIndex7);
        Console.WriteLine($"{nameof(isSame)} : {isSame}");

        currencyIndexToAmount.AddOrUpdate(currencyIndex1, 1, before => before + 1);
        currencyIndexToAmount.AddOrUpdate(currencyIndex2, 1, before => before + 1);
        currencyIndexToAmount.AddOrUpdate(currencyIndex3, 1, before => before + 1);
        currencyIndexToAmount.AddOrUpdate(currencyIndex4, 1, before => before + 1);
        currencyIndexToAmount.AddOrUpdate(currencyIndex5, 1, before => before + 1);
        currencyIndexToAmount.AddOrUpdate(currencyIndex6, 1, before => before + 1);
        currencyIndexToAmount.AddOrUpdate(currencyIndex7, 1, before => before + 1);
        currencyIndexToAmount.AddOrUpdate(currencyIndex8, 1, before => before + 1);

        Console.WriteLine($"----------------origin----------------------");

        foreach (var (index, amount) in currencyIndexToAmount)
        {
            Console.WriteLine($"{index} : {amount}");
        }

        Console.WriteLine($"------------------not equal--------------------");

        var currencyIndexToAmount2 = currencyIndexToAmount.ToDictionary(pair => pair.Key, pair => pair.Value);
        currencyIndexToAmount2.AddOrUpdate(currencyIndex9, 1, before => before + 1);

        foreach (var (index, amount) in currencyIndexToAmount2)
        {
            Console.WriteLine($"{index} : {amount}");
        }
        Console.WriteLine($"-----------------equal---------------------");

        var currencyIndexToAmount3 = currencyIndexToAmount.ToDictionary(pair => pair.Key, pair => pair.Value, CurrencyIndexEqualComparer.Instance);
        currencyIndexToAmount3.AddOrUpdate(currencyIndex9, 1, before => before + 1);
        foreach (var (index, amount) in currencyIndexToAmount3)
        {
            Console.WriteLine($"{index} : {amount}");
        }
    }
}
