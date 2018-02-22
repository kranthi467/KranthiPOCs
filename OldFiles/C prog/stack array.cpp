#include<stdio.h>
#include<stdlib.h>
#define MAX 50
int stack[MAX],top=-1;
void push(int ele)
	{
		if(top==MAX)
		printf("List is full element cannot be inserted\n");
		else
			stack[++top]=ele;
	}
int pop()
{
	int ele=-1;
	if(top==-1)
	printf("List is empty, cannot pop element\n");
	else
		ele=stack[top--];
	return ele;	
}	
int gettop()
{
	int ele;
	if(top==-1)
	printf("List is empty, cannot get top element\n");
	else
	ele=stack[top];
	return ele;
}
int size()
{
	return top+1;
}
void display()
{
	int i;
	if(top==-1)
	printf("List is empty, cannot get top element\n");
	for(i=0;i<=top;i++)
	printf("%d ",stack[i]);
	printf("\n");
}
main()
{
	int ele,ch;
	while(1)
	{
		printf("Enter an choice:\n\t1.push\n\t2.pop\n\t3.gettop\n\t4.size\n\t5.display\n\t6.Exit.\n");
		scanf("%d",&ch);
		switch(ch)
		{
			case 1:printf("Enter an element to push\n");
				   scanf("%d",&ele);
				   push(ele);
				   break;
			case 2: ele=pop();
					if(ele!=-1)
					printf("Element deleted is %d",ele);
					break;
			case 3: ele=gettop();	
			        if(ele!=-1)
					printf("Element at top is %d",ele);
					break;		  
			case 4: printf("Size is %d\n",size());
					break;
			case 5:display();
					break;
			case 6:exit(0);	
			default:printf("Invalid choice\n");				  	
		}
	}
}

