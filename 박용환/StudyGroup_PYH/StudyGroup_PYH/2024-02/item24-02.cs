using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

// AttributeUsage는 C#에서 제공하는 언어의 기능 중 하나이며, 속성(Attribute)에 대한 사용 규칙을 지정하는 데 사용
// DefaultSort attribute로 Name 프로퍼티를 정한 Customer 객체를 포함하는 collection을
// 기본적으로 Name 프로퍼티를 사용하여 정렬하도록 하는 코드
// DefaultSort attribute는 .NET 런타임이 기본적으로 인식하지 않으므로, DefaultSortAttribute를 구현해야 함
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class DefaultSortAttribute : System.Attribute
{
    private string name;

    // Attribute에 부여할 프로퍼티
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // Attribute 생성자
    public DefaultSortAttribute(string name)
    {
        this.name = name;
    }
}

public class Customer
{
    private string name;
    private decimal balance; // 십진 부동소수점

    // 정렬 기준 프로퍼티
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // 읽기 전용 프로퍼티
    public decimal Balance
    {
        get { return balance; }
    }

    // 읽기 전용 프로퍼티, 계산 로직이 포함됨
    public decimal AccountValue
    {
        get { return CalculateValueOfAccount(); }
    }

    // 비교 대상 객체들을 정렬의 기준이 되는 프로퍼티에 대한 정보를 저장하는 GenericComparer 클래스
    internal class GenericComparer : IComparer
    {
        private readonly PropertyDescriptor sortProp;
        private readonly bool reverse = false;

        // 생성자 - 정렬 기준 프로퍼티 설정
        public GenericComparer(Type t)
            : this(t, false)
        {
        }

        // 생성자 - 정렬 기준 프로퍼티 및 정렬 방식 설정
        public GenericComparer(Type t, bool reverse)
        {
            // type 내의 기본 정렬기준 attribute 획득
            object[] a = t.GetCustomAttributes(typeof(DefaultSortAttribute), false);

            // 프로퍼티의 PropertyDescriptor 획득
            if (a.Length > 0)
            {
                DefaultSortAttribute sortName = a[0] as DefaultSortAttribute;
                string name = sortName.Name;

                // 정렬기준 프로퍼티 초기화
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(t);

                if (props.Count > 0)
                {
                    foreach (PropertyDescriptor p in props)
                    {
                        if (p.Name == name)
                        {
                            // 기본 정렬기준 프로퍼티가 찾아지면
                            sortProp = p;
                            break;
                        }
                    }
                }
            }
        }

        #region IComparer Members
        // Compare 메서드 구현
        public int Compare(object left, object right)
        {
            // null은 모든 객체보다 작다
            if ((left == null) && (right == null))
                return 0;

            if (left == null)
                return -1;

            if (right == null)
                return 1;

            if (sortProp == null)
                return 0;

            // 각 객체의 정렬기준 프로퍼티를 획득
            IComparable lField = sortProp.GetValue(left) as IComparable;
            IComparable rField = sortProp.GetValue(right) as IComparable;
            int rVal = 0;

            if (lField == null)
            {
                if (rField == null)
                    return 0;
                else
                    return -1;
            }

            rVal = lField.CompareTo(rField);
            return (reverse) ? -rVal : rVal;
        }
        #endregion
    }

    // 계좌 가치 계산 로직
    private decimal CalculateValueOfAccount()
    {
        return 0;
    }
}