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
main()
{
int a[50],n,i;
printf("Enter no of elemets to be sorted\n");
scanf("%d",&n);
printf("Enter array elements\n");
for(i=0;i<n;i++)
scanf("%d",&a[i]);
printf("Elements sorting . . .\n");
bubblesort(a,n);
printf("Elements after sort\n\n");
for(i=0;i<n;i++)
printf("%d ",a[i]);
printf("\n");
}
