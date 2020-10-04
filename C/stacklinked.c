#include<stdio.h>
#include<stdlib.h>
#define MAX 50
struct stack
{
int data;
struct stack *next;
}*stack;
int size=0;
struct stack *newnode;
void push(int ele)
	{
		newnode=malloc(sizeof(struct stack));
		newnode->data=ele;
		newnode->next=NULL;
		if(stack==NULL)
			stack=newnode;
		else
{
			newnode->next=stack;
			stack=newnode;
}
size++;
	}
int pop()
{
	int ele=-1;
	if(stack==NULL)
	printf("Empty stack\n");
	else
	{
	newnode=stack;
	stack=newnode->next;
	ele=newnode->data;	
	newnode->next=NULL;
	free(newnode);
	}
	size--;
	return ele;	
}	
int gettop()
{
	int ele=-1;
	if(stack==NULL)
	printf("Empty stack\n");
	else
	{
	ele=stack->data;
	}
	return ele;		
}
int findsize()
{
	return size;
}
void display()
{
	newnode=stack;
	if(stack==NULL)
	printf("List is empty, cannot get element\n");
	while(newnode!=NULL)
	{
	printf("%d->",newnode->data);
	newnode=newnode->next;
	}
	printf("NULL\n");
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
					printf("Element deleted is %d \n",ele);
					break;
			case 3: ele=gettop();	
			        if(ele!=-1)
					printf("Element at top is %d\n",ele);
					break;		  
			case 4: printf("Size is %d\n",findsize());
					break;
			case 5:display();
					break;
			case 6:exit(0);	
			default:printf("Invalid choice\n");				  	
		}
	}
}

