#pragma once
class Line
{
	float x, y, l;int a;
public:
	Line();
	Line(float x, float y, float l, int a);
	virtual  ~Line();
	void Show();
	void Edit();
	void MoveTo();
	void ChangeAngle();
};

