#include<stdio.h>
#include<stdlib.h>
#define MAX 50
struct queue
{
int data;
struct queue *next;
}*queue;
int size=0;
struct queue *newnode,*temp;
void enqueue(int ele)
	{
		newnode=malloc(sizeof(struct queue));
		newnode->data=ele;
		newnode->next=NULL;
		temp=queue;
		if(queue==NULL)
			queue=newnode;
		else
		{
			while(temp->next!=NULL)
			{
			temp=temp->next;
			}
		temp->next=newnode;
		}
size++;
	}
int dequeue()
{
	int ele=-1;
	if(queue==NULL)
	printf("Empty queue\n");
	else
	{
	newnode=queue;
	queue=newnode->next;
	free(newnode);
	}
	size--;
	return ele;	
}	
int findsize()
{
	return size;
}
void display()
{
	newnode=queue;
	if(queue==NULL)
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
		printf("Enter an choice:\n\t1.enqueue\n\t2.dequeue\n\t3.size\n\t4.display\n\t5.Exit.\n");
		scanf("%d",&ch);
		switch(ch)
		{
			case 1:printf("Enter an element to enqueue\n");
				   scanf("%d",&ele);
				   enqueue(ele);
				   break;
			case 2: ele=dequeue();
					if(ele!=-1)
					printf("Element deleted is %d \n",ele);
					break;
				  
			case 3: printf("Size is %d\n",findsize());
					break;
			case 4:display();
					break;
			case 5:exit(0);	
			default:printf("Invalid choice\n");				  	
		}
	}
}

