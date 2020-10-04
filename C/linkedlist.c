#include<stdio.h>
#include<stdlib.h>
#define MAX 50
struct listnode
{
int data;
struct listnode *next;
};
int size=0;
struct listnode *head=NULL;
void insertbegin(int ele)
{
if(size==MAX)
{
printf("operation cannot be performed, list is full\n");
return;
}
struct listnode *newnode;
newnode=malloc(sizeof(struct listnode));
newnode->data=ele;
newnode->next=NULL;
if(head==NULL)
{
head=newnode;
}
else
{
newnode->next=head;
head=newnode;
}
size++;
}
void insertend(int ele)
{

if(size==MAX)
{
printf("operation cannot be performed, list is full\n");
return;
}
struct listnode *newnode,*temp;
newnode=malloc(sizeof(struct listnode));
newnode->data=ele;
newnode->next=NULL;
if(head==NULL)
{
head=newnode;
}
else
{
temp=head;
while(temp->next!=NULL)
{
temp=temp->next;
}
temp->next=newnode;
}
size++;
}
void insertpos(int ele,int pos)
{
int i;
struct listnode *newnode,*temp;
newnode=malloc(sizeof(struct listnode));
newnode->data=ele;
newnode->next=NULL;
if(size==MAX)
{
printf("operation cannot be performed, list is full\n");
return;
}
if(pos==1)
{
insertbegin(ele);
}

else
{
struct listnode *temp=head;
if(pos>1&&pos<=size+1)
{
for(i=1;i<pos-1;i++)
{
temp=temp->next;
}
newnode->next=temp->next;
temp->next=newnode;
}
else
{
printf("Invalid position %d\n",pos);
}
}
size++;
}
int deletebegin()
{
int ele;
struct listnode *temp;
if(size==0)
{
printf("operation cannot be performed, list is empty\n");
return -1;
}
ele=head->data;
temp=head;
head=head->next;
free(temp);
size--;
return ele;
}
int deleteend()
{
int ele;
struct listnode *ptemp=NULL,*temp;
if(size==0)
{
printf("operation cannot be performed, list is empty\n");
return(-1);
}
temp=head;
while(temp->next!=NULL)
{
ptemp=temp;
temp=temp->next;
}
if(temp==head)
head=NULL;
else
ptemp->next=NULL;
ele=temp->data;
free(temp);
size--;
return ele;
}
int deletepos(int pos)
{
int i,ele;
struct listnode *ptemp=NULL,*temp;
if(size==0)
{
printf("operation cannot be performed, list is empty\n");
return(-1);
}
else
{
if(pos>=1&&pos<=size+1)
{
temp=head;
i=1;
while(i<pos)
{
ptemp=temp;
temp=temp->next;
i++;
}
ptemp->next=temp->next;
ele=temp->data;
free(temp);
size--;
return ele;
}
else
{
printf("invalid position %d",pos);
}
}
}
int deleteele(int ele)
{
int i=0;
struct listnode *temp;
if(head==NULL)
printf("List is empty\n");
else
{
temp=head;
while(temp!=NULL)
{
if(ele==temp->data)
{
return deletepos(i);
}
else
{
temp=temp->next;
i++;
}
}
size--;
printf("\n%d not found in  list",ele);
}
return -1;
}
int  findsize()
{
return size;
}
void display()
{
struct listnode *temp=head;
while(temp!=NULL)
{
printf("%d->",temp->data);
temp=temp->next;
}
printf("NULL\n");
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
	case 4:ele=deletebegin();
		if(ele!=0)
		printf("The element at position is %d\n",ele);
		break;
	case 5:ele=deleteend();
		if(ele!=-1)
		printf("The element at position is %d\n",ele);
		break;
	case 6:printf("Enter an elements position\n");
		scanf("%d",&pos);
		ele=deletepos(pos);
		if(ele!=-1)
		printf("The element at position is %d\n",ele);
		break;
	case 7:printf("Enter an element\n");
		scanf("%d",&ele);
		ele=deleteele(ele);
		if(ele!=-1)
		printf("The element at position is %d\n",ele);
		break;
	case 8:printf("Size=%d\n",findsize());
		break;
	case 9:display();
		break;
	case 10:exit(0);
	default:printf("Invalid option,%d\n",op);
}
}
}
	


















