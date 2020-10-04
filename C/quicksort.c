#include<stdio.h>
void quicksort(int a[],int low,int high)
{
int pivot,first,last,temp;
if(low<high)
{
pivot=low;
first=low;
last=high;
while(first<last)
{
while(a[first]<=a[pivot]&&first<high)
first++;
while(a[last]>a[pivot])
last--;
if(first<last)
{
temp=a[first];
a[first]=a[last];
a[last]=temp;
}}
temp=a[last];
a[last]=a[pivot];
a[pivot]=temp;
quicksort(a,low,last-1);
quicksort(a,last+1,high);
}}
main()
{
int a[50],n,i;
printf("Enter no of elemets to be sorted\n");
scanf("%d",&n);
printf("Enter array elements\n");
for(i=0;i<n;i++)
scanf("%d",&a[i]);
quicksort(a,0,n-1);
printf("Elements after sort\n");
for(i=0;i<n;i++)
printf("%d ",a[i]);
printf("\n");
}

