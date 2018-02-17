#pragma once
class Point
{
private:
	float x, y;
public:
	Point();
	Point(float dx,float dy);
	void Set(float dx, float dy);
	float GetX();
	float GetY();
	~Point();
};

