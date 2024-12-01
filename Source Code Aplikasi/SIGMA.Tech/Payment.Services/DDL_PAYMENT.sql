CREATE DATABASE POS_SIGMA;
DROP table TBPayment;
CREATE TABLE TBPayment(
    id INT IDENTITY(1,1) NOT NULL,  -- Automatically increments for each new record
    due_date DATE,
    amount NUMERIC,
    payment_allocated NUMERIC NULL,
    updated_on DATETIME NULL,
    CONSTRAINT pk_payment PRIMARY KEY CLUSTERED (id ASC)
);


INSERT INTO TBPayment (due_date, amount) VALUES ('2023-01-10', 165000);
INSERT INTO TBPayment (due_date, amount) VALUES ('2023-02-15', 80000);
INSERT INTO TBPayment (due_date, amount) VALUES ('2023-01-20', 130000);
INSERT INTO TBPayment (due_date, amount) VALUES ('2023-03-23', 416000);
INSERT INTO TBPayment (due_date, amount) VALUES ('2023-02-10', 95500);
INSERT INTO TBPayment (due_date, amount) VALUES ('2023-08-17', 523000);




Select * from TBPayment order by due_date

CREATE TABLE TBPaymentInvoice (
  id INT IDENTITY(1,1) not null, 
  payment_id int not null,
  pmt_date date,
  pmt_amount numeric,
  CONSTRAINT pk_payment_invoice PRIMARY KEY CLUSTERED (id ASC),
  CONSTRAINT fk_payment FOREIGN KEY (payment_id) REFERENCES TBPayment(id) 
);

INSERT INTO TBPaymentInvoice (payment_id, pmt_date, pmt_amount) Values (1, '2023-01-10',165000);
INSERT INTO TBPaymentInvoice (payment_id, pmt_date, pmt_amount) Values (3, '2023-01-10',130000);
INSERT INTO TBPaymentInvoice (payment_id, pmt_date, pmt_amount) Values (5, '2023-01-10',95500);
INSERT INTO TBPaymentInvoice (payment_id, pmt_date, pmt_amount) Values (2, '2023-01-10',30000);
INSERT INTO TBPaymentInvoice (payment_id, pmt_date, pmt_amount) Values (2, '2023-01-10',50000);
INSERT INTO TBPaymentInvoice (payment_id, pmt_date, pmt_amount) Values (4, '2023-01-10',50000);



Select * from TBPayment;


SELECT
     COUNT(CASE WHEN due_date > '2023-03-25' THEN 1 END) AS Total_Undue,
     COUNT(CASE WHEN due_date <= '2023-03-25' THEN 1 END) AS Total_Overdue
FROM TBPayment;


