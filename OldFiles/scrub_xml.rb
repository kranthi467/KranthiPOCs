require_relative '../tools/scrub_xml'

##########################################################################
#
# These are the file locations for where the load and save locations are.
# If the load and save locations are the same the original file will be
# overwritten by this script.
#
#########################################################################
loadFile = "C:/Users/WPrimeau/Downloads/APRIL_Colib_0000267_20180123T11-28-07.xml"
writeFile = "C:/Users/WPrimeau/Downloads/APRIL_Colib_0000267_20180123T11-28-07_Scrubbed.xml"

##########################################################################
#
# These are used for values that may need to be unique between file runs.
# The script will pull these values in in the appropriate places. If you
# have a need to make them unique between files you will need to update
# these values before you run.
#
#########################################################################
unique_ssn_prefix = "222222222"
unique_taxid_prefix = "222222222"
email_prefix = "test@testerson.com"

##########################################################################
#
# These are the paths that will be searched for in the file. Unless you
# have a very good reason to change these you should leave the paths the
# way they are. If you wish to modify any of the replacement values that
# will not need to be unique file over file this is the place to do that.
# Note that all of these values will have an incremental number appended
# to the end so that they are unique across the file.
#
# The values in this array are as follow:
# 0 - Display name for printed results
# 1 - XPath to node in XML
# 2 - Replacement text
# 3 - Max length for field or nil if it doesn't matter
# 4 - Symbol that the number needs to be added before, for instances like
#     email addresses
# 5 - Whether to add dashes into an SSN or not (true/false)
#
#########################################################################
#
# TODO: REPLACE THE LAST FEW ARGUMENTS TO EACH ARRAY WITH A BLOCK THAT CAN BE
# EXECUTED DYNAMICALLY - MUCH CLEANER IMPLEMENTATION AND GIVES YOU LINE BY LINE
# FLEXIBILITY OVER EXECUTION.
#
xpaths = [
    [ "Broker first name", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:Brokers//tns:Broker//tns:Name//tns:FirstName", "TestBrokerF", nil, nil, nil],
    [ "Broker last name", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:Brokers//tns:Broker//tns:Name//tns:LastName", "TestBrokerL", nil, nil, nil],
    [ "Firm name", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:Firms//tns:Firm/tns:Name", "Firm", nil, nil, nil],
    [ "Tax ID", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:SmallGroupCoverage//tns:Group//tns:TaxID", unique_taxid_prefix, 9, nil, 2],
    [ "Group name", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:SmallGroupCoverage//tns:Group/tns:Name", "Group", nil, nil, nil],
    [ "Group address", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:SmallGroupCoverage//tns:Group//tns:Addresses//tns:Address//tns:Street_1", "123 Street", nil, nil, nil],
    [ "Administrator first name", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:SmallGroupCoverage//tns:Group//tns:Administrators//tns:Administrator//tns:Name//tns:FirstName", "TestAdminF", nil, nil, nil],
    [ "Administrator last name", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:SmallGroupCoverage//tns:Group//tns:Administrators//tns:Administrator//tns:Name//tns:LastName", "TestAdminL", nil, nil, nil],
    [ "Administrator email", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:SmallGroupCoverage//tns:Group//tns:Administrators//tns:Administrator//tns:EmailAddress", email_prefix, nil, "@", nil],
    [ "Administrator phone number", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:SmallGroupCoverage//tns:Group//tns:Administrators//tns:Administrator//tns:PhoneNumbers//tns:Number", "8434448888", 10, nil, nil],
    [ "Subgroup name", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:SmallGroupCoverage//tns:Group//tns:SubGroups//tns:SubGroup/tns:Name", "SubgroupNm", nil, nil, nil],
    [ "Subgroup address", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:SmallGroupCoverage//tns:Group//tns:SubGroups//tns:SubGroup//tns:Addresses//tns:Address//tns:Street_1", "123 Street", nil, nil, nil],
    [ "Contact first name", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:SmallGroupCoverage//tns:Group//tns:SubGroups//tns:SubGroup//tns:Contacts//tns:Contact//tns:Name//tns:FirstName", "TestContactF", nil, nil, nil],
    [ "Contact last name", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:SmallGroupCoverage//tns:Group//tns:SubGroups//tns:SubGroup//tns:Contacts//tns:Contact//tns:Name//tns:LastName", "TestContactL", nil, nil, nil],
    [ "Contact email", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:SmallGroupCoverage//tns:Group//tns:SubGroups//tns:SubGroup//tns:Contacts//tns:Contact//tns:EmailAddress", email_prefix, nil, "@", nil],
    [ "Contact phone number", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:SmallGroupCoverage//tns:Group//tns:SubGroups//tns:SubGroup//tns:Contacts//tns:Contact//tns:PhoneNumbers//tns:Number", "8434448888", 10, nil, nil],
    [ "Contact address", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:SmallGroupCoverage//tns:Group//tns:SubGroups//tns:SubGroup//tns:Contacts//tns:Contact//tns:Addresses//tns:Address//tns:Street_1", "123 Street", nil, nil, nil],
    [ "Employee address", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:SmallGroupCoverage//tns:Employees//tns:Employee//tns:Addresses//tns:Address//tns:Street_1", "123 Street", nil, nil, nil],
    [ "Employee phone number", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:SmallGroupCoverage//tns:Employees//tns:Employee//tns:PhoneNumbers//tns:Number", "8434448888", 10, nil, nil],
    [ "Employee email", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:SmallGroupCoverage//tns:Employees//tns:Employee//tns:Email", email_prefix, nil, "@", nil],
    [ "Member first name", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:SmallGroupCoverage//tns:Employees//tns:Employee//tns:Members//tns:Member//tns:Name//tns:FirstName", "TestMemberF", nil, nil, nil],
    [ "Member last name", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:SmallGroupCoverage//tns:Employees//tns:Employee//tns:Members//tns:Member//tns:Name//tns:LastName", "TestMemberL", nil, nil, nil],
    [ "Member SSN", "//tns:PolicyBatchRequest//tns:Policies//tns:Policy//tns:SmallGroupCoverage//tns:Employees//tns:Employee//tns:Members//tns:Member//tns:SSN", unique_ssn_prefix, 9, nil, 1]
]

# Execute the script
ScrubXML.new.scrub(loadFile, writeFile, xpaths)