#include<stdio.h>
void insertionsort(int a[],int n)
{
int i,j,temp;
for(i=1;i<n;i++)
{
temp=a[i];
j=i-1;
while(j>=0&&a[j]>temp)//finds pos for ith ele at j+1
{
a[j+1]=a[j];
j--;
}
a[j+1]=temp;
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
insertionsort(a,n);
printf("Elements after sort\n");
for(i=0;i<n;i++)
printf("%d ",a[i]);
printf("\n");
}
