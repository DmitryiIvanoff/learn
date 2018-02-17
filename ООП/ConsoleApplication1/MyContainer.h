#pragma once

template<typename T>class MyContainer
{
protected:
	T *Cont; // ��������� �� ���������
	int size; // ������ ����������
	T top; // ������� ����������
	float x, y, x1 = 0, x2 = 0, x3 = 0, y1 = 0, y2 = 0, y3 = 0, r, l, h, poluos;
	int rotation = 0, a;
public:

	MyContainer(int = 10);//�� ��������� ������=10
	virtual ~MyContainer();
	template<typename T>void operator ++(){
		AfxMessageBox(L"++");
	};//���������� ���������
	bool push(const T); // ��������� ������� � ���������
	bool pop(); // ������� �� ���������� �������
	void Show();// �������� ���������
	void Edit();//������������� ����������, ����� �� ����� �� ������� ���������
	void ChangeAngle();//�������� ���� � �����
	void Resize();//�������� ������ ����������
	void Rotate();//������� ������, �����, ����, ���������������
	void MoveTo(int charCode);//������� ������
};

template<typename T>MyContainer<T>::MyContainer(int s)
{
	size = s > 0 ? s : 10;   // ���������������� ������ ����������
	Cont = new T[size]; // �������� ������ ��� ���������
	top = -1; // �������� -1 ������� � ���, ��� ��������� ����
	std::cout << "Good";;
};

template<typename T>MyContainer<T>::~MyContainer()
{
	delete[] Cont;
};

template <typename T>bool MyContainer<T>::push(const T Obj)
{
	if (top == size - 1)return false; // ��������� �����
	top++;
	Cont[top] = Obj; // �������� ������� � ���������
	return true; // �������� ���������� ��������
};

template <typename T>bool MyContainer<T>::pop()
{
	if (top == -1)return false; // ��������� ����
	Cont[top] = NULL; // ������� ������� �� ����������
	top--;
	return true; // �������� ���������� ��������
};

// ����� ����� �� �����
template <typename T>void MyContainer<T>::Show()
{
	for (int ix = size - 1; ix >= 0; ix--)Cont[ix];
};
