#pragma once
#include "�Figure.h"
#include "Circle.h"
#include "Line.h"
#include "Ellipsoid.h"
#include "Quadrangle.h"
#include "Rhombus.h"

struct Node       //��������� ���������� ������ ������
{
	�Figure* x;     //�������� x ����� ������������ � ������
	Node *Next, *Prev; //��������� �� ������ ���������� � ����������� ��������� ������
};

class MyContainer   //������� ��� ������ ������
{
	Node *Head, *Tail; //��������� �� ������ ������ ������ � ��� �����
	int length = 0;
public:
	MyContainer() :Head(NULL), Tail(NULL),length(0){}; //�������������� ������ ��� ������
	~MyContainer(); //����������
	void Give(char ch,int code); //������� ����������� ������ �� ������
	void OnChangeradius();//����� �������
	void Add(�Figure* x); //������� ���������� ��������� � ������
	int Length(); //������� ����� �������
};

void MyContainer::OnChangeradius(){

}

MyContainer::~MyContainer() //����������
{
	while (Head) //���� �� ������ �� ������ ������ ���-�� ����
	{
		Tail = Head->Next; //��������� ����� ������ ���������� ����� ������
		delete Head; //������� ������ �� ������� �����
		Head = Tail; //����� ������ ������ �� ����� ���������� ��������
	}
}

int MyContainer::Length(){//����� �������
	return length;
}

void MyContainer::Add(�Figure* x)
{
	length += 1;
	Node *temp = new Node; //��������� ������ ��� ����� ������� ���������
	temp->Next = NULL;  //���������, ��� ���������� �� ���������� ������ �����
	temp->x = x;//���������� �������� � ���������

	if (Head != NULL) //���� ������ �� ����
	{
		temp->Prev = Tail; //��������� ����� �� ���������� ������� � �����. ����
		Tail->Next = temp; //��������� ����� ���������� �� ������� ��������
		Tail = temp; //������ ����� ������
	}
	else //���� ������ ������
	{
		temp->Prev = NULL; //���������� ������� ��������� � �������
		Head = Tail = temp; //������=�����=��� �������, ��� ������ ��������
	}
}

void MyContainer::Give(char ch,int code)
{
	Node *temp = Tail;//��������� ��������� �� ����� ���������� ��������
	switch (ch)
	{
	case 's':{//���������� ������
		//������� ������ � ������
		temp = Head; //�������� ��������� �� ����� ������� ��������
		while (temp != NULL) //���� �� �������� ������ ��������
		{
			temp->x->Show(); //������� ������ �� �����
			temp = temp->Next; //����� ������ �� ����� ���������� ��������
		}
	}; break;
	case 'm':{//������� �� �������
				 //������� ������ � ������
				 temp = Head; //�������� ��������� �� ����� ������� ��������
				 while (temp != NULL) //���� �� �������� ������ ��������
				 {
					 temp->x->MoveTo(code); //������� ������ �� �����
					 temp = temp->Next; //����� ������ �� ����� ���������� ��������
				 }
	}; break;
	case 'r':{//������ �����
				 temp = Head; //�������� ��������� �� ����� ������� ��������
				 while (temp != NULL) //���� �� �������� ������ ��������
				 {
					 if (dynamic_cast<Circle*>(temp->x)){
						 temp->x->Resize();
					 }
					 temp = temp->Next; //����� ������ �� ����� ���������� ��������
				 }
	}; break;
	case 't':{//����� ����- ��������
				 temp = Head; //�������� ��������� �� ����� ������� ��������
				 while (temp != NULL) //���� �� �������� ������ ��������
				 {
					 if (dynamic_cast<Line *>(temp->x)){
						 temp->x->ChangeAngle();
					 }
					 if (dynamic_cast<Ellipsoid *>(temp->x) || dynamic_cast<Quadrangle *>(temp->x) || dynamic_cast<Rhombus *>(temp->x)){
						 temp->x->Rotate();
					 }
					 temp = temp->Next; //����� ������ �� ����� ���������� ��������
				 }
	}; break;
	case 'e':{//������� ������
				 temp = Head; //�������� ��������� �� ����� ������� ��������
				 while (temp != NULL) //���� �� �������� ������ ��������
				 {
					 //37 - left; 38 -up;39- right;40-down
					 int flag = 37 + rand() / (RAND_MAX / 3);
					 if (dynamic_cast<Ellipsoid *>(temp->x)){
						 temp->x->MoveTo(flag);
					 }
					 temp = temp->Next; //����� ������ �� ����� ���������� ��������
				 }
	}; break;
	case 'q':{//������� ���������������
				 temp = Head; //�������� ��������� �� ����� ������� ��������
				 while (temp != NULL) //���� �� �������� ������ ��������
				 {
					 //37 - left; 38 -up;39- right;40-down
					 int flag = 37 + rand() / (RAND_MAX / 3);
					 if (dynamic_cast<Quadrangle *>(temp->x)){
						 temp->x->MoveTo(flag);
					 }
					 temp = temp->Next; //����� ������ �� ����� ���������� ��������
				 }
	}; break;
	case 'o':{//move ����
				 temp = Head; //�������� ��������� �� ����� ������� ��������
				 while (temp != NULL) //���� �� �������� ������ ��������
				 {
					 //37 - left; 38 -up;39- right;40-down
					 int flag = 37 + rand() / (RAND_MAX / 3);
					 if (dynamic_cast<Rhombus *>(temp->x)){
						 temp->x->MoveTo(flag);
					 }
					 temp = temp->Next; //����� ������ �� ����� ���������� ��������
				 }
	}; break;
	case 'l':{//move line
				 temp = Head; //�������� ��������� �� ����� ������� ��������
				 while (temp != NULL) //���� �� �������� ������ ��������
				 {
					 //37 - left; 38 -up;39- right;40-down
					 int flag = 37 + rand() / (RAND_MAX / 3);
					 if (dynamic_cast<Line *>(temp->x)){
						 temp->x->MoveTo(flag);
					 }
					 temp = temp->Next; //����� ������ �� ����� ���������� ��������
				 }
	}; break;
	case 'd':{//move ring
				 temp = Head; //�������� ��������� �� ����� ������� ��������
				 while (temp != NULL) //���� �� �������� ������ ��������
				 {
					 //37 - left; 38 -up;39- right;40-down
					 int flag = 37 + rand() / (RAND_MAX / 3);
					 if (dynamic_cast<Circle *>(temp->x)){
						 temp->x->MoveTo(flag);
					 }
					 temp = temp->Next; //����� ������ �� ����� ���������� ��������
				 }
	}; break;
	default:
		break;
	}
}
