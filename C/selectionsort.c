#include<stdio.h>
void swap(int *p,int *q)
{
int t;
t=*p;
*p=*q;
*q=t;
}
void selectionsort(int a[],int n)
{
int min,pos,i;
for(pos=0;pos<n;pos++)
{
 min=pos;
 for(i=pos+1;i<n;i++)
 {
  if(a[i]<a[min])
    min=i;
 }
 if(min!=pos)
   swap(&a[min],&a[pos]);
}
}
main()
{
int a[50],n,i;
printf("Enter no of elemets to be sorted\n");
scanf("%d",&n);
printf("Enter array elements\n");
for(i=0;i<n;i++)
scanf("%d",&a[i]);
printf("Elements b4 sort\n");
for(i=0;i<n;i++)
printf("%d ",a[i]);
printf("\n");
selectionsort(a,n);
printf("Elements after sort\n");
for(i=0;i<n;i++)
printf("%d ",a[i]);
printf("\n");
}
