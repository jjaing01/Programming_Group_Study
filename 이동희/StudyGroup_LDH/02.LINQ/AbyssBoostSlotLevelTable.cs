namespace testLinq;

using System.Collections.Generic;

/// <summary>
/// 심연 증폭 슬롯 레벨 데이터 입니다.
/// </summary>
public partial class AbyssBoostSlotLevelData
{
    /// <summary>
    /// 심연 증폭 슬롯 Id 입니다.
    /// </summary>
    public int SlotUid { get; set; }

    /// <summary>
    /// 심연 증폭 슬롯 레벨 입니다.
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// 심연 증폭 슬롯 해금 카테고리 티어 입니다.
    /// </summary>
    public int UnlockAbyssBoostCategoryTier { get; set; }

    /// <summary>
    /// 보상 스탯 (스피드) 입니다.
    /// </summary>
    public int Speed { get; set; }
}

/// <summary>
/// 심연 증폭 슬롯 레벨 테이블입니다.
/// </summary>
public partial class AbyssBoostSlotLevelTable
{
    /// <summary>
    /// 심연 슬롯 레벨 데이터 목록입니다.
    /// </summary>
    public List<AbyssBoostSlotLevelData> list { get; set; }
}

