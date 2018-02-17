#pragma once
class Circle
{
	float x, y, r;
public:
	Circle(float dx, float dy, float dr);
	Circle();
	virtual  ~Circle();
	void Show();
	void Edit();
	void MoveTo();
	void Resize();
};

