#pragma once
//����������� �����
class �Figure 
{
protected://����� �� ����������� ������� ���� ��������
	float x, y, x1 = 0, x2 = 0, x3 = 0, y1 = 0, y2 = 0, y3 = 0;
public:
	�Figure();
	�Figure(float dx,float dy);
	virtual void Show() = 0;
	virtual void Edit() = 0;
	virtual void ChangeAngle();
	virtual void Resize();
	virtual void Rotate();
	virtual void MoveTo(int charCode);//�.�. ������� ������ - ��������� � ����� ������
	virtual ~�Figure();
};

