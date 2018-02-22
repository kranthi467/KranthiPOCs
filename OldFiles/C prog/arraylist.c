#include<stdio.h>
#include<stdlib.h>
#define MAX 50
int a[MAX],size;
void insertbegin(int ele)
{
	int i;
	if(size==MAX)
	printf("List is full operation cannot be performed\n");
	else
	{
	for(i=size-1;i>=0;i--)
	 {
           a[i+1]=a[i];
	 }
	a[0]=ele;
        size++;
	}
}
void insertend(int ele)
{
	if(size==MAX)
	printf("List is full ,operation cannot be performed\n");
	else
	{
	a[size]=ele;
	size++;
	}
}
void insertpos(int ele,int pos)
{
	int i;
	if(size==MAX)
	printf("list is full,operation cannot be performed\n");
	else 
	{
	 if(pos>=1&&pos<=size+1)
	  {
	   for(i=size-1;i>=pos-1;i--)
		a[i+1]=a[i];
	a[i+1]=ele;	
 	size++;
	   }
	 else
		printf("Invalid position,%d \n",pos);
         }
}
int delbegin()
{
	int i,temp=-1;
	if(size==0)
	{
	printf("list is empty,operation cannot be performed\n");
	return temp;
	}	
	else
	{
	temp=a[0];
	for(i=0;i<size;i++)
	a[i]=a[i+1];
	size--;
	}
	return temp;
}
int delend()
{
	int temp=-1;
	if(size==0)
	{
	printf("List is empty,operation cannot be performed\n");
	return temp;
	}
	else
	temp=a[--size];
	return temp;
}
int delpos(int pos)
{
	int temp=-1,i;
	if(size==0)
	{
	printf("List is empty,operation cannot be performed\n");
	}
	else
	{
	if(pos>=0&&pos<size)
	{
	temp=a[pos-1];
	for(i=pos;i<size;i++)
	a[i]=a[i+1];
	size--;
	}
	else
	printf("Invalid position entry %d\n",pos);
	}	
	return temp;	
}
int delele(int ele)
{
	int i,temp=-1;
	if(size==0)
	{
	printf("List is empty,operation cannot be performed\n");
	return temp;
	}
	else 
	for(i=0;i<size;i++)
	if(a[i]==ele)
	return delpos(i+1);
}
int findsize()
{
return size;
}
void display()
{
int i;
for(i=0;i<size;i++)
printf("%d ",a[i]);
printf("\n");
}
main()
{
int op,ele,pos;
while(1)
{
	printf("Menu:\n\t");
	printf("1.Insert at begining\n\t2.Insert at end\n\t3.Insert at position\n\t4.Delete at begining\n\t5.Delete at End\n\t6.Delete at position\n\t7.Delete Given element\n\t8.Size\n\t9.Display numbers\n\t10.Exit\n");
	scanf("%d",&op);
	switch(op)
	{
	case 1:printf("Enter an element\n");
		scanf("%d",&ele);
		insertbegin(ele);
		break;
	case 2:printf("Enter an element\n");
		scanf("%d",&ele);
		insertend(ele);
		break;
	case 3:printf("Enter an element and its position\n");
		scanf("%d%d",&ele,&pos);
		insertpos(ele,pos);
		break;
	case 4:ele=delbegin();
		if(ele!=0)
		printf("The element at position is %d\n",ele);
		break;
	case 5:ele=delend();
		if(ele!=-1)
		printf("The element at position is %d\n",ele);
		break;
	case 6:printf("Enter an elements position\n");
		scanf("%d",&pos);
		ele=delpos(pos);
		if(ele!=-1)
		printf("The element at position is %d\n",ele);
		break;
	case 7:printf("Enter an element\n");
		scanf("%d",&ele);
		ele=delele(ele);
		if(ele!=-1)
		printf("The element at position is %d\n",ele);
		break;
	case 8:ele=findsize();
		printf("Size=%d\n",ele);
		break;
	case 9:display();
		break;
	case 10:exit(0);
	default:printf("Invalid option,%d\n",op);
}
}
}
	
