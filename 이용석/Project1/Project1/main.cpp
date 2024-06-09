#include <iostream>

using namespace std;

static constexpr uint16_t aSize = 3;

static void PrintArray(const uint16_t pArray[][aSize], const uint16_t pArraySize)
{
	cout <<"--------------------------" << endl;

	for (int i = 0; i < pArraySize; ++i)
	{
		for (int j = 0; j < pArraySize; ++j)
		{
			cout << pArray[j][i];
		}
		cout << endl;
	}

	cout << "--------------------------" << endl;
}

int main(void)
{

	uint16_t aArray[aSize][aSize];
	uint16_t aLeftRotate[aSize][aSize];
	uint16_t aRightRotate[aSize][aSize];
	uint16_t aIdx = 0;

	for (int i = 0; i < aSize; ++i)
	{
		for (int j = 0; j < aSize; ++j)
		{
			aArray[j][i] = ++aIdx;
		}
	}

	PrintArray(aArray, aSize);

	for (int i = 0; i < aSize; ++i)
	{
		for (int j = 0; j < aSize; ++j)
		{
			aRightRotate[i][j] = aArray[j][aSize - i - 1];
		}
	}

	PrintArray(aRightRotate, aSize);

	for (int i = 0; i < aSize; ++i)
	{
		for (int j = 0; j < aSize; ++j)
		{
			aLeftRotate[j][aSize - i - 1] = aArray[i][j];
		}
	}
	PrintArray(aLeftRotate, aSize);


	return 0;
}