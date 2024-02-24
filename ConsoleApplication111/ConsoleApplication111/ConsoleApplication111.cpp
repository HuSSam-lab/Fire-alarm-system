#include <iostream>
#include<string>
#include<math.h>
using namespace std;
float flo(string g) {
	int x = g.length() - 1;
	int z;
	z = g.find(".");
	return 0.5 * (1 / pow(10, x - z));
}


void main() {
	string input1, input2;
	char x;
	float e0, e1, x0, x1;

	cout << "Enter first Number ";
	cin >> input1;

	x0 = stof(input1);
	e0 = flo(input1);

	cout << "x0=" << x0 << "\t" << "e0=" << e0 << "\n";
	cout << "Enter second number" << "\n";
	cin >> input2;

	x1 = stof(input2);
	e1 = flo(input2);

	cout << "x1=" << x1 << "\t" << "e1=" << e1 << "\n";
	cout << "Enter the operation\n";
	cin >> x;


	switch (x)
	{
	case '+':
		cout << "E x+y=" << e1 + e0;
		break;
	case'-':
		cout << "E x-y=" << e1 + e0;
		break;
	case'*':
		cout << "E x*y=" << e0 * fabs(x1) + e1 * fabs(x0);
		break;
	case'/':
		cout << "E x/y=\n" << ((e0 / fabs(x1)) + ((e1 * fabs(x0) / (x1 * x1))));
	}
}


