using System.Collections.Generic;

namespace testLinq;

/// <summary>
/// 심연 증폭 카테고리 데이터입니다.
/// </summary>
public partial class AbyssBoostCategoryData
{
    /// <summary>
    /// 심연 증폭 카테고리 ID 입니다.
    /// </summary>
    public int Uid { get; set; }

    /// <summary>
    /// 심연 증폭 카테고리 해금 심연 레벨입니다.
    /// /// </summary>
    public int UnlockAbyssLevel { get; set; }

    /// <summary>
    /// 심연 증폭 카테고리의 직업 정보입니다.
    /// 직업과 관련있는 카테고리를 구분하는 용도입니다.
    /// </summary>
    public ClassType Class { get; set; }
}

/// <summary>
/// 심연 증폭 카테고리 테이블입니다.
/// </summary>
public partial class AbyssBoostCategoryTable
{
    /// <summary>
    /// 심연 증폭 카테고리 데이터 목록입니다.
    /// </summary>
    public Dictionary<int /* AbyssBoostCategoryUid */, AbyssBoostCategoryData> dict { get; set; }
}
