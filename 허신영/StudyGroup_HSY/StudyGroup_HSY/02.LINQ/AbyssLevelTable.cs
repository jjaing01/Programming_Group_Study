namespace testLinq;

using System;
using System.Collections.Generic;

/// <summary>
/// 심연 레벨 데이터입니다.
/// </summary>
public partial class AbyssLevelData
{
    /// <summary>
    /// 심연 레벨입니다.
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// 해금 시각입니다.
    /// </summary>
    public DateTime UnlockDateTime { get; set; }
}

/// <summary>
/// 심연 레벨 테이블입니다.
/// </summary>
public partial class AbyssLevelTable
{
    /// <summary>
    /// 심연 레벨 데이터 목록입니다.
    /// </summary>
    public List<AbyssLevelData> list { get; set; }
}