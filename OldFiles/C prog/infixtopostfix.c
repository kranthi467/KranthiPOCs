#include<stdio.h>
#define MAX 50
int top=-1;
char stack[MAX];
char ele;
char pop()
{
return stack[top--];
}
void push(char ele)
{
stack[++top]=ele;
}
int priority(char ele)
{
switch(ele)
{
case '#':return 0;
case '(':return 1;
case '+':
case '-':return 2;
case '*':
case '/':return 3;
}
}

void intopostfix(char in[],char po[])
{
char ch;
int i=0,p=0;
while((ch=in[i++])!='\0')
{
if(isalpha(ch))
{
po[p++]=ch;
}
else if(ch=='(')
{
push(ch);
}
else if(ch==')')
{
while(stack[top]!='(')
{
po[p++]=pop();
}
ele=pop();
}
else 
{
while(priority(stack[top])>=priority(ch))
{
po[p++]=pop();
}
push(ch);
}
}
while(stack[top]!='#')
{
po[p++]=pop();
}
po[p]='\0';
}
main()
{
char in[MAX],po[MAX];
printf("Enter the infix expression\n");
scanf("%s",in);
push('#');
intopostfix(in,po);
printf("the postfix expression\n");
printf("%s\n\n\n",po);
}
