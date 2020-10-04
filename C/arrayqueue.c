#include<stdio.h>
#include<stdlib.h>
#define MAX 50
int queue[MAX],r=0,f=0;
void enqueue(int ele)
	{
		if(r==MAX)
		printf("List is full element cannot be inserted\n");
		else
		{
			queue[r]=ele;
			r++;
		}
	}
int dequeue()
{
	int ele=-1;
	if(f==r)
	{
	printf("List is empty, cannot dequeue element\n");
	f=r=0;
	}
	else
		{
		ele=queue[f];
		f++;
		}
	return ele;	
}	
int size()
{
	return r-f;
}
void display()
{
	int i;
	if(f==r)
	printf("List is empty, cannot get top element\n");
	for(i=f;i<r;i++)
	printf("%d ",queue[i]);
	printf("\n");
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
					printf("Element deleted is %d",ele);
					break;
			
			case 3: printf("Size is %d\n",size());
					break;
			case 4:display();
					break;
			case 5:exit(0);	
			default:printf("Invalid choice\n");				  	
		}
	}
}

