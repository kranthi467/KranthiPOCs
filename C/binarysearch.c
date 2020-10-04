#include<stdio.h>
void bubblesort(int a[],int n)
{
int i,j,t;
for(i=0;i<n-1;i++)
 {
  for(j=0;j<n-i-1;j++)
   {
     if(a[j]>a[j+1])
       {
        t=a[j];
        a[j]=a[j+1];
        a[j+1]=t;
       }
    }
 }
}
int ibsearch(int key,int a[],int n)
{
int f,l,m;
f=0;
l=n-1;
while(f<=l)
{
m=(f+l)/2;
if(key==a[m])
return m;
if(key<a[m])
l=m-1;
else
f=m+1;
}
return -1;
}
int rbsearch(int key,int a[],int f,int l)
{
int m;
if(f<=l)
{
m=(f+l)/2;
if(key==a[m])
return m;
if(key<a[m])
return rbsearch(key,a,f,m-1);
else 
return rbsearch(key,a,m+1,l);
}
return -1;
}
main()
{
int n,k,a[50],i,pos,op,f,l;
printf("Enter no of elements\n");
scanf("%d",&n);
printf("Enter elements to be searched\n");
for(i=0;i<n;i++)
scanf("%d",&a[i]);
printf("Enter The key to be searched\n");
scanf("%d",&k);
printf("Enter \n\t1.For iteration\n\t2.for recursion\n");
scanf("%d",&op);
bubblesort(a,n);
switch(op)
{
case 1:pos=ibsearch(k,a,n);
       break;
case 2:f=0;
       l=n-1;
       pos=rbsearch(k,a,f,l);
       break;
} 
printf("The position is %d",pos+1);
}



