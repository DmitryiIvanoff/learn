#pragma once
//����������� �����
class �Figure abstract
{
protected://����� �� ����������� ������� ���� ��������
	float x, y;
public:
	�Figure();
	�Figure(float dx,float dy);
	virtual void Show()abstract = 0;
	virtual void Edit()abstract = 0;
	virtual void MoveTo();//�.�. ������� ������ - ��������� � ����� ������
	virtual ~�Figure();
};

