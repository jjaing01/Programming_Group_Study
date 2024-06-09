namespace testLinq;

using System;
using System.Collections.Generic;

/// <summary>
/// 심연 증폭 카테고리 티어 데이터입니다.
/// </summary>
public partial class AbyssBoostCategoryTierData
{
    /// <summary>
    /// 심연 증폭 카테고리 ID 입니다.
    /// </summary>
    public int AbyssBoostCategoryUid { get; set; }

    /// <summary>
    /// 해금 시각 입니다.
    /// </summary>
    public DateTime UnlockDateTime { get; set; }
}

/// <summary>
/// 심연 증폭 카테고리 티어 테이블입니다.
/// </summary>
public partial class AbyssBoostCategoryTierTable
{
    /// <summary>
    /// 심연 레벨 카테고리 티어 데이터 목록입니다.
    /// </summary>
    public List<AbyssBoostCategoryTierData> list { get; set; }
}