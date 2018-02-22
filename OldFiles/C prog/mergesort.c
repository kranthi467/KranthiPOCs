#include<stdio.h>

void merge(int a[],int first,int mid,int last)
{
int temp[50],i,j,k;
i=k=first;
j=mid+1;
while(i<=mid&&j<=last)
{
if(a[i]<=a[j])
temp[k++]=a[i++];
else
temp[k++]=a[j++];
}
if(i>mid)
while(j<=last)
temp[k++]=a[j++];
if(j>mid)
while(i<=last)
temp[k++]=a[i++];
for(k=first;k<=last;k++)
a[k]=temp[k];
}
void mergesort(int a[],int first,int last)
{
int mid;
if(first<last)
{
mid=(first+last)/2;
mergesort(a,first,mid);
mergesort(a,mid+1,last);
merge(a,first,mid,last);
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
printf("Elements after sort\n");
mergesort(a,0,n-1);

for(i=0;i<n;i++)
printf("%d ",a[i]);
printf("\n");
}

