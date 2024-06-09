namespace testLinq;

using System.Collections.Generic;

/// <summary>
/// 심연 증폭 슬롯 데이터입니다.
/// </summary>
public partial class AbyssBoostSlotData
{
    /// <summary>
    /// 심연 증폭 슬롯 ID 입니다.
    /// </summary>
    public int Uid { get; set; }

    /// <summary>
    /// 심연 증폭 슬롯 카테고리 ID 입니다.
    /// 심연 증폭 슬롯이 배치될 카테고리 ID 입니다.
    /// </summary>
    public int AbyssBoostCategoryUid { get; set; }
}

/// <summary>
/// 심연 증폭 슬롯 테이블입니다.
/// </summary>
public partial class AbyssBoostSlotTable
{
    /// <summary>
    /// 심연 증폭 슬롯 데이터 목록입니다.
    /// </summary>
    public Dictionary<int /* AbyssBoostSlotUid */, AbyssBoostSlotData> dict { get; set; }
}

