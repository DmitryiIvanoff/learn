#pragma once
//����������� �����
class �Figure 
{
protected://����� �� ����������� ������� ���� ��������
	float x, y;
public:
	�Figure();
	�Figure(float dx,float dy);
	virtual void Show() = 0;
	virtual void Edit() = 0;
	virtual void MoveTo();//�.�. ������� ������ - ��������� � ����� ������
	virtual ~�Figure();
};

